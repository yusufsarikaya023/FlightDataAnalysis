using Domain.Aggregation.Flights;
using Infrastructure.Repositories;

namespace Test.InfrastructureIntegrationTest.Repositories;

public class FlightRepositoryTest(RepositoryFixture fixture): IClassFixture<RepositoryFixture>
{
    // setup
    private readonly FlightRepository _repository = new(fixture.Context);

    [Fact]
    public async Task FlightRepository_Should_Add_Flight()
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
            .SetAirCraftId(airCraft.Id);
        
        // Act
        await _repository.Add(flight);
        await fixture.Context.SaveChangesAsync(CancellationToken.None);
        var inserted = await fixture.Context.Flights.FindAsync(flight.Id);
        
        // Assert
        inserted!.FlightNumber.Should().Be(flight.FlightNumber);
        inserted.DepartureDateTime.Should().Be(flight.DepartureDateTime);
        inserted.ArrivalDateTime.Should().Be(flight.ArrivalDateTime);
        inserted.DepartureAirportId.Should().Be(flight.DepartureAirportId);
        inserted.ArrivalAirportId.Should().Be(flight.ArrivalAirportId);
        inserted.AirCraftId.Should().Be(flight.AirCraftId);
    }
    
    [Fact]
    public async Task FlightRepository_Should_Get_Unchecked_Flights()
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
        
        // Act
        await _repository.Add(flight);
        await fixture.Context.SaveChangesAsync(CancellationToken.None);
        
        var flights = await _repository.GetUncheckedFlights();
        
        // Assert
        flights.Should().NotBeNullOrEmpty();
    }
}