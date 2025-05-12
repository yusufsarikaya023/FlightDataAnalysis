using Domain.Aggregation.Flights;
using Function.Functions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Test.FunctionalTest.Functions;

[Collection("FunctionalCollection")]
public class CheckFlightConsistencyTimerTriggerTest(FunctionFixture fixture)
{
    private readonly CheckFlightConsistencyTimerTrigger _sut = new(fixture.Host.Services.GetRequiredService<IMediator>());

    [Fact]
    public async Task CheckFlightConsistencyTimerTrigger_Should_Execute_At_Specified_Time()
    {
        // Arrange
        var departureAirport = Faker.GetFakeAirport();
        var arrivalAirport = Faker.GetFakeAirport();
        fixture.Context.Airports.AddRange(departureAirport, arrivalAirport);
        
        var airCraft = Faker.GetFakeAirCraft();
        fixture.Context.AirCrafts.Add(airCraft);
        // Save changes to get the Ids
        await fixture.Context.SaveChangesAsync(CancellationToken.None);
        
        var flight = Faker.GetFakeFlight();
        flight.SetDepartureAirportId(departureAirport.Id)
            .SetArrivalAirportId(arrivalAirport.Id)
            .SetAirCraftId(airCraft.Id)
            .SetConsistencyType(FlightConsistencyType.Unchecked);
        
        fixture.Context.Add(flight);
        await fixture.Context.SaveChangesAsync(CancellationToken.None);
        fixture.Context.Entry(flight).State = EntityState.Detached;
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
        var inserted = await fixture
            .Context.Flights
            .FirstAsync(x=> x.Id == flight.Id);

        // Assert
        Assert.NotNull(inserted);
        Assert.NotEqual(FlightConsistencyType.Unchecked, inserted.ConsistencyType);
    }
}