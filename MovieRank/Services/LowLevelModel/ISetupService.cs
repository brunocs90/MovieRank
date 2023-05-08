namespace MovieRank.Services.LowLevelModel
{
    public interface ISetupService
    {
        Task CreateDynamoDbTable(string dynamoDbTableName);

        Task DeleteDynamoDbTable(string dynamoDbTableName);
    }
}
