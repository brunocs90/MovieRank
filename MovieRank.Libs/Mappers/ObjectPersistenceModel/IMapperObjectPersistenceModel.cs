using MovieRank.Contracts;
using MovieRank.Libs.Models;

namespace MovieRank.Libs.Mappers.ObjectPersistenceModel
{
    public interface IMapperObjectPersistenceModel
    {
        IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDb> items);

        MovieResponse ToMovieContract(MovieDb movie);

        MovieDb ToMovieDbModel(int userId, MovieRankRequest movieRankRequest);

        MovieDb ToMovieDbModel(int userId, MovieDb movieDbRequest, MovieUpdateRequest movieUpdateRequest);
    }
}
