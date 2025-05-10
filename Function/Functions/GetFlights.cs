using System.Net;
using Application.Common;
using Application.UseCases.FlightData;
using Function.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace Function.Functions;

public class GetFlights(ILogger<GetFlights> logger, IMediator mediator)
{
    [Function("GetFlights")]
    [ValidateRequest(typeof(Pagination))]
    [OpenApiOperation("GetFlightDataFunction")]
    [OpenApiRequestBody("application/json", typeof(Pagination))]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(string))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");

        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonConvert.DeserializeObject<Pagination>(requestBody);
        var result = await mediator.Send(new GetFlightDataQuery());
        return new OkObjectResult(result);
    }
}