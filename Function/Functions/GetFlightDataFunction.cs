using Application.UseCases.FlightData;


namespace Function.Functions;

public class GetFlightDataFunction(ILogger<GetFlightDataFunction> logger, IMediator mediator)
{
    [Function("GetFlightDataFunction")]
   
public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");

        var request = new GetFlightDataQuery();
        var result = await mediator.Send(request);
        return new OkObjectResult(result);
    }
}