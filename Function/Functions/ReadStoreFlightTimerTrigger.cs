using Application.UseCases.FlightData;

namespace Function.Functions;

public class ReadStoreFlightTimerTrigger(ILogger<ReadStoreFlightTimerTrigger> logger, IMediator mediator)
{
    [Function("Timer")]
    public async Task Run([TimerTrigger("*/1 * * * * *")] TimerInfo myTimer)
    {
        logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

        var command = new ReadStoreFlightCommand();
        await mediator.Send(command);

        if (myTimer.ScheduleStatus is not null)
        {
            logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }
}