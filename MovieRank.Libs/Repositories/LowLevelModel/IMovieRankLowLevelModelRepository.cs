using Amazon.DynamoDBv2.Model;
using MovieRank.Contracts;

namespace MovieRank.Libs.Repositories.LowLevelModel
{
    public interface IMovieRankLowLevelModelRepository
    {
        Task<ScanResponse> GetAllItems();

        Task<GetItemResponse> GetMovie(int userId, string movieName);

        Task<QueryResponse> GetUsersRankedMoviesByMovieTitle(int userId, string movieName);

        Task AddMovie(int userId, MovieRankRequest movieRankRequest);

        Task UpdateMovie(int userId, MovieUpdateRequest updateRequest);

        Task<QueryResponse> GetMovieRank(string movieName);

        Task CreateDynamoTable(string tableName);

        Task DeleteDynamoDbTable(string tableName);

    }
}
