using System.Net;
using Application.UseCases.FlightData;
using Application.UseCases.FlightData.DTO;

namespace Function.Functions;

public class GetInconsistentFlights(IMediator mediator)
{
    [Function("GetInconsistentFlights")]
    [OpenApiOperation("GetInconsistentFlights")]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(FlightDto[]))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        var result = await mediator.Send(new GetInconsistentFlightsQuery());
        return new OkObjectResult(result);
    }
}