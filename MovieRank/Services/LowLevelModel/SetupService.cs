using MovieRank.Libs.Repositories.LowLevelModel;

namespace MovieRank.Services.LowLevelModel
{
    public class SetupService : ISetupService
    {
        private readonly IMovieRankLowLevelModelRepository _movieRankLowLevelModelRepositoryRespository;

        public SetupService(IMovieRankLowLevelModelRepository movieRankLowLevelModelRepositoryRespository)
        {
            _movieRankLowLevelModelRepositoryRespository = movieRankLowLevelModelRepositoryRespository;
        }

        public async Task CreateDynamoDbTable(string dynamoDbTableName)
        {
            await _movieRankLowLevelModelRepositoryRespository.CreateDynamoTable(dynamoDbTableName);
        }

        public async Task DeleteDynamoDbTable(string dynamoDbTableName)
        {
            await _movieRankLowLevelModelRepositoryRespository.DeleteDynamoDbTable(dynamoDbTableName);
        }
    }
}
