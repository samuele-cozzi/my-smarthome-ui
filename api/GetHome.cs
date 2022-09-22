namespace api
{
    public class GetHome
    {
        private readonly ILogger<GetHome> _logger;

        public GetHome(ILogger<GetHome> log)
        {
            _logger = log;
        }

        [FunctionName("GetHome")]
        [StorageAccount("AzureStateStorage")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [Blob("home-state/home", FileAccess.Read)] string reader
        )
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(reader);
        
        }
    }
}
