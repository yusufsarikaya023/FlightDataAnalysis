namespace Test.InfrastructureIntegrationTest;

[CollectionDefinition("InfrastructureCollection")]
public record InfrastructureCollection : ICollectionFixture<RepositoryFixture>;