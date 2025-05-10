using Application.UseCases.FlightData;

namespace Function.Functions;

public class CheckFlightConsistencyTimerTrigger(ILogger<ReadStoreFlightTimerTrigger> logger, IMediator mediator)
{
    [Function("CheckFlightConsistencyTimerTrigger")]
    public async Task Run([TimerTrigger("*/1 * * * * *")] TimerInfo myTimer)
    {
        logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        var command = new CheckFlightConsistencyCommand();
        await mediator.Send(command);

        if (myTimer.ScheduleStatus is not null)
        {
            logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }
}