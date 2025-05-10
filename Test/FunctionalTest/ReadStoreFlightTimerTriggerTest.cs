using Application.UseCases.FlightData;
using Function.Functions;

namespace Test.FunctionalTest;

public class ReadStoreFlightTimerTriggerTest
{
    [Fact]
    public async Task ReadFlightTimerTrigger_Should_Execute_At_Specified_Time()
    {
        // Arrange
        var logger = new Mock<ILogger<ReadStoreFlightTimerTrigger>>();
        
        var mediator = new Mock<IMediator>();

        var scheduleStatus = new ScheduleStatus()
        {
            Last = DateTime.UtcNow.AddMinutes(-1),
            Next = DateTime.UtcNow.AddMinutes(1),
            LastUpdated = DateTime.UtcNow
        };

        var timerInfo = new TimerInfo
        {
            ScheduleStatus = scheduleStatus,
            IsPastDue = false,
        };

        var trigger = new ReadStoreFlightTimerTrigger(logger.Object, mediator.Object);

        // Act
        await trigger.Run(timerInfo);

        // Assert
        logger.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((state, t) =>
                    state.ToString()!.Contains("executed at")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()!),
            Times.AtLeastOnce);
        mediator.Verify(m => m.Send(It.IsAny<ReadStoreFlightCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}