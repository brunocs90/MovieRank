using Xunit;

namespace MovieRank.Integration.Tests.Setup
{
    [CollectionDefinition("api")]
    public class CollectionFixture : ICollectionFixture<TestContext>
    {
    }
}
