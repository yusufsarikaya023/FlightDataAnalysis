using Application.UseCases.FlightData;

namespace Function.Functions;

public class ReadStoreFlightTimerTrigger(IMediator mediator)
{
    [Function("ReadStoreFlightTimerTrigger")]
    public async Task Run([TimerTrigger("*/1 * * * * *")] TimerInfo myTimer)
    {
        var command = new ReadStoreFlightCommand();
        await mediator.Send(command);
    }
}