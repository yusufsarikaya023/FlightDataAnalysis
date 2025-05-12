namespace Test.InfrastructureIntegrationTest;

/// <summary>
/// This class is responsible for defining the collection of infrastructure integration tests.
/// </summary>
[CollectionDefinition("InfrastructureCollection")]
public record InfrastructureCollection : ICollectionFixture<RepositoryFixture>;