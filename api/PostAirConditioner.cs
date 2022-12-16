namespace api
{
    public class PostAirConditioner
    {
        private readonly ILogger<PostAirConditioner> _logger;

        public PostAirConditioner(ILogger<PostAirConditioner> log)
        {
            _logger = log;
        }

        [FunctionName("PostAirConditioner")]
        [StorageAccount("AzureStateStorage")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "air-conditioner" })]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(AirConditioner))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] AirConditioner req,
            [Blob("home-state/ac-controller/{DeviceId}", FileAccess.Write)] TextWriter stateACController,
            [Blob("home-state/home", FileAccess.Read)] string reader,
            [Blob("home-state/home", FileAccess.Write)] TextWriter writer
        )
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var home = JsonConvert.DeserializeObject<Home>(reader);
            
            //-----------------------------------------------------------------------------
            var iotAC = new HomeIotHubAirConditioner(){
                enabled = Convert.ToInt32(home.Configuration.Enabled),
                interval = home.Configuration.IntervalThermostat,
                power = Convert.ToInt32(req.Power),
                mode = req.Mode,
                temperature = req.Temp,
                fan = req.Fan
            };

            var serviceClient = ServiceClient.CreateFromConnectionString(Environment.GetEnvironmentVariable("AzureIotHubConnectionString"));
            var commandMessage = new Message(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(iotAC)));
                
            await serviceClient.SendAsync(req.DeviceId, commandMessage);

            _logger.LogInformation("Cloud2Device message sent!");

            //-----------------------------------------------------------------------------

            await stateACController.WriteLineAsync(JsonConvert.SerializeObject(req));

            _logger.LogInformation("Blob Storage Air Conditioner Saved!");

            //-----------------------------------------------------------------------------

            home.AirConditioners.RemoveAll(x => x.DeviceId == req.DeviceId);
            home.AirConditioners.Add(req);
            
            writer.WriteLine(JsonConvert.SerializeObject(home));

            _logger.LogInformation("Blob Storage Home Saved!");

            //-----------------------------------------------------------------------------

            return new OkObjectResult("OK");
        }
    }
}
