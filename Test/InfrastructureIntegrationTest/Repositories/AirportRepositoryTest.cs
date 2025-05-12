using Infrastructure.Repositories;

namespace Test.InfrastructureIntegrationTest.Repositories;

/// <summary>
/// This class is responsible for testing the AirCraftRepository.
/// </summary>
[Collection("InfrastructureCollection")]
public class AirportRepositoryTest(RepositoryFixture fixture)
{
    private readonly AirportRepository _repository = new(fixture.Context);

    /// <summary>
    /// This method is responsible for testing the Add method of the AirCraftRepository.
    /// </summary>
    [Fact]
    public async Task AirportRepository_Should_Add_Airport()
    {
        // Arrange
        var airport = Faker.GetFakeAirport();

        // Act
        await _repository.Add(airport);
        await fixture.Context.SaveChangesAsync();
        var inserted = await fixture.Context.Airports.FindAsync(airport.Id);

        // Assert
        inserted!.Name.Should().Be(airport.Name);
        inserted.Code.Should().Be(airport.Code);
    }
    
    /// <summary>
    /// This method is responsible for testing the GetByCode method of the AirCraftRepository.
    /// </summary>
    [Fact]
    public async Task AirportRepository_Should_Get_Airport_By_Code()
    {
        // Arrange
        var airport = Faker.GetFakeAirport();
        await _repository.Add(airport);
        await fixture.Context.SaveChangesAsync();
        
        // Act
        var inserted = await _repository.GetByCode(airport.Code);
        
        // Assert
        inserted.Should().NotBeNull();
        inserted!.Name.Should().Be(airport.Name);
        inserted.Code.Should().Be(airport.Code);
        inserted.Id.Should().Be(airport.Id);
    }
}