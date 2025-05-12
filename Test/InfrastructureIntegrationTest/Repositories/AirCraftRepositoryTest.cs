using Infrastructure.Repositories;

namespace Test.InfrastructureIntegrationTest.Repositories;

/// <summary>
/// This class is responsible for testing the AirCraftRepository.
/// </summary>
/// <param name="fixture"></param>

[Collection("InfrastructureCollection")]
public class AirCraftRepositoryTest(RepositoryFixture fixture)
{
    // setup
    private readonly AirCraftRepository _repository = new(fixture.Context);
    
    /// <summary>
    /// This method is responsible for testing the Add method of the AirCraftRepository.
    /// </summary>
    [Fact]
    public async Task AirCraftRepository_Should_Add_AirCraft()
    {
        // Arrange
        var airCraft = Faker.GetFakeAirCraft();
    
        // Act
        await _repository.Add(airCraft);
        await fixture.Context.SaveChangesAsync();
        var inserted = await fixture.Context.AirCrafts.FindAsync(airCraft.Id);
    
        // Assert
        inserted!.AircraftType.Should().Be(airCraft.AircraftType);
        inserted.RegistrationNumber.Should().Be(airCraft.RegistrationNumber);
    }

    /// <summary>
    /// This method is responsible for testing the GetByRegistrationNumber method of the AirCraftRepository.
    /// </summary>
    [Fact]
    public async Task AirCraftRepository_Should_Get_AirCraft_By_RegistrationNumber()
    {
        // Arrange
        var airCraft = Faker.GetFakeAirCraft();
        await _repository.Add(airCraft);
        await fixture.Context.SaveChangesAsync();
        
        // Act
        var inserted = await _repository.GetByRegistrationNumber(airCraft.RegistrationNumber);
        
        // Assert
        inserted.Should().NotBeNull();
        inserted!.AircraftType.Should().Be(airCraft.AircraftType);
        inserted.RegistrationNumber.Should().Be(airCraft.RegistrationNumber);
        inserted.Id.Should().Be(airCraft.Id);
    }
}