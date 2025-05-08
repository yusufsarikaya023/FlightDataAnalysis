using System.Net;
using Application.UseCases.FlightData;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;


namespace Function.Functions;

public class GetFlightDataFunction(ILogger<GetFlightDataFunction> logger, IMediator mediator)
{
    [Function("GetFlightDataFunction")]
    [OpenApiOperation(operationId: "GetFlightDataFunction")]
    [OpenApiRequestBody("application/json", typeof(GetFlightDataQuery))]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function,  "post")] HttpRequest req)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");

        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonConvert.DeserializeObject<GetFlightDataQuery>(requestBody);
        var result = await mediator.Send(data!);
        return new OkObjectResult(result);
    }
}