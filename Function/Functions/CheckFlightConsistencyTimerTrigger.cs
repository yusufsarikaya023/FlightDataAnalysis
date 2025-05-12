using Application.UseCases.FlightData;

namespace Function.Functions;

public class CheckFlightConsistencyTimerTrigger(IMediator mediator)
{
    [Function("CheckFlightConsistencyTimerTrigger")]
    public async Task Run([TimerTrigger("*/1 * * * * *")] TimerInfo myTimer)
    {
        var command = new CheckFlightConsistencyCommand();
        await mediator.Send(command);
    }
}