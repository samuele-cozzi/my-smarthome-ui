namespace api
{
    public class PostConfiguration
    {
        private readonly ILogger<PostConfiguration> _logger;

        public PostConfiguration(ILogger<PostConfiguration> log)
        {
            _logger = log;
        }

        [FunctionName("PostConfiguration")]
        [StorageAccount("AzureStateStorage")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(HomeConfiguration))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [Blob("home-state/home_configuration", FileAccess.Write)] TextWriter configuration,
            [Blob("home-state/home", FileAccess.Read)] string reader,
            [Blob("home-state/home", FileAccess.Write)] TextWriter writer,
            [HttpTrigger(AuthorizationLevel.Anonymous,"post", Route = null)] HttpRequest req
        )
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            //-----------------------------------------------------------------------------

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            HomeConfiguration data = JsonConvert.DeserializeObject<HomeConfiguration>(requestBody);
            await configuration.WriteLineAsync(JsonConvert.SerializeObject(data));

            //-----------------------------------------------------------------------------

            var home = JsonConvert.DeserializeObject<Home>(reader);
            home.Configuration = data;            
            writer.WriteLine(JsonConvert.SerializeObject(home));

            _logger.LogInformation("Blob Storage Home Saved!");

            //-----------------------------------------------------------------------------

            return new OkObjectResult("OK");
        }
    }
}
