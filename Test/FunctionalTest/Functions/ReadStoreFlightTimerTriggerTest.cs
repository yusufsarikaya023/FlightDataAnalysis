using Application.UseCases.FlightData;
using Domain.Aggregation.Flights;
using Function.Functions;
using Microsoft.Extensions.DependencyInjection;

namespace Test.FunctionalTest.Functions;

[Collection("FunctionalCollection")]
public class ReadStoreFlightTimerTriggerTest(FunctionFixture fixture)
{
    private readonly ReadStoreFlightTimerTrigger _sut = new(fixture.Host.Services.GetRequiredService<IMediator>());

    [Fact]
    public async Task ReadFlightTimerTrigger_Should_Execute_At_Specified_Time()
    {
        // Arrange
        var scheduleStatus = new ScheduleStatus
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

        // Act
        await _sut.Run(timerInfo);
        var flights = fixture.Context.Flights.Where(x => x.ConsistencyType == FlightConsistencyType.Unchecked).ToList();

        // Assert
        Assert.NotNull(flights);
        Assert.NotEmpty(flights);
    }
}