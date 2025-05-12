namespace Test.FunctionalTest;

/// <summary>
/// This class is responsible for defining the collection of functional tests.
/// </summary>
[CollectionDefinition("FunctionalCollection")]
public record FunctionalCollection : ICollectionFixture<FunctionFixture>;