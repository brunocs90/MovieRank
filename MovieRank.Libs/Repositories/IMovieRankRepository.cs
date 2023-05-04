using MovieRank.Libs.Models;

namespace MovieRank.Libs.Repositories
{
    public interface IMovieRankRepository
    {
        Task<IEnumerable<MovieDb>> GetAllItems();

    }
}
