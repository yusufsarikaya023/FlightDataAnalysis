using System.Net;
using Application.Common;
using Application.UseCases.FlightData;
using Application.UseCases.FlightData.DTO;
using Function.Attributes;
using Newtonsoft.Json;

namespace Function.Functions;

/// <summary>
/// Function to get flight data with pagination.
/// </summary>
/// <param name="mediator"> The mediator to send queries.</param>

public class GetFlights(IMediator mediator)
{
    [Function("GetFlights")]
    [ValidateRequest(typeof(Pagination))]
    [OpenApiOperation("GetFlightDataFunction")]
    [OpenApiRequestBody("application/json", typeof(Pagination))]
    [OpenApiResponseWithBody(HttpStatusCode.OK, "application/json", typeof(FlightDto[]))]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonConvert.DeserializeObject<Pagination>(requestBody);
        var result = await mediator.Send(new GetFlightDataQuery(data!));
        return new OkObjectResult(result);
    }
}