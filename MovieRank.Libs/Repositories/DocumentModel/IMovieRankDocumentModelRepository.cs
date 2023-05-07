using Amazon.DynamoDBv2.DocumentModel;

namespace MovieRank.Libs.Repositories.DocumentModel
{
    public interface IMovieRankDocumentModelRepository
    {
        Task<IEnumerable<Document>> GetAllItems();

        Task<Document> GetMovie(int userId, string movieName);

        Task<IEnumerable<Document>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName);

        Task AddMovie(Document documentModel);

        Task UpdateMovie(Document documentModel);

        Task<IEnumerable<Document>> GetMovieRank(string movieName);

    }
}
