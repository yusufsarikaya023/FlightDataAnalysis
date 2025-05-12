using Application.UseCases.FlightData;

namespace Function.Functions;

/// <summary>
/// Timer trigger function to check flight consistency.
/// </summary>
/// <param name="mediator"> The mediator to send commands.</param>
public class CheckFlightConsistencyTimerTrigger(IMediator mediator)
{
    [Function("CheckFlightConsistencyTimerTrigger")]
    public async Task Run([TimerTrigger("*/1 * * * * *")] TimerInfo myTimer)
    {
        var command = new CheckFlightConsistencyCommand();
        await mediator.Send(command);
    }
}