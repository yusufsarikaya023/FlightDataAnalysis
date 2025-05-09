using FluentAssertions;
using Infrastructure.Repositories;

namespace Test.InfrastructureIntegrationTest.Repositories;

public class AirCraftRepositoryTest(RepositoryFixture fixture) : IClassFixture<RepositoryFixture>
{
    // setup
    private AirCraftRepository _repository = new(fixture.Context);
    
    
    [Fact]
    public async Task AirCraftRepository_Should_Add_AirCraft()
    {
        // Arrange
        var airCraft = Faker.GetFakeAirCraft();
    
        // Act
        _repository.Add(airCraft);
        await fixture.Context.SaveChangesAsync();
        var inserted = await fixture.Context.AirCrafts.FindAsync(airCraft.Id);
    
        // Assert
        inserted!.AircraftType.Should().Be(airCraft.AircraftType);
        inserted.RegistrationNumber.Should().Be(airCraft.RegistrationNumber);
    }
}