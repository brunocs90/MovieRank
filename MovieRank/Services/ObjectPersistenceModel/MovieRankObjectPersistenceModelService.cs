using MovieRank.Contracts;
using MovieRank.Libs.Mappers.ObjectPersistenceModel;
using MovieRank.Libs.Repositories.ObjectPersistenceModel;

namespace MovieRank.Services.ObjectPersistenceModel
{
    public class MovieRankObjectPersistenceModelService : IMovieRankObjectPersistenceModelService
    {
        private readonly IMovieRankObjectPersistenceModelRepository _movieRankObjectPersistenceModelRepository;
        private readonly IMapperObjectPersistenceModel _mapperObjectPersistenceModel;

        public MovieRankObjectPersistenceModelService(IMovieRankObjectPersistenceModelRepository movieRankRepository, IMapperObjectPersistenceModel mapperObjectPersistenceModel)
        {
            _movieRankObjectPersistenceModelRepository = movieRankRepository;
            _mapperObjectPersistenceModel = mapperObjectPersistenceModel;
        }

        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var response = await _movieRankObjectPersistenceModelRepository.GetAllItems();

            return _mapperObjectPersistenceModel.ToMovieContract(response);
        }

        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var response = await _movieRankObjectPersistenceModelRepository.GetMovie(userId, movieName);

            return _mapperObjectPersistenceModel.ToMovieContract(response);
        }

        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var response = await _movieRankObjectPersistenceModelRepository.GetUsersRankedMoviesByMovieTitle(userId, movieName);

            return _mapperObjectPersistenceModel.ToMovieContract(response);
        }

        public async Task AddMovie(int userId, MovieRankRequest movieRankRequest)
        {
            var movieDb = _mapperObjectPersistenceModel.ToMovieDbModel(userId, movieRankRequest);

            await _movieRankObjectPersistenceModelRepository.AddMovie(movieDb);
        }

        public async Task UpdateMovie(int userId, MovieUpdateRequest request)
        {
            var response = await _movieRankObjectPersistenceModelRepository.GetMovie(userId, request.MovieName);

            var movieDb = _mapperObjectPersistenceModel.ToMovieDbModel(userId, response, request);

            await _movieRankObjectPersistenceModelRepository.UpdateMovie(movieDb);
        }

        public async Task<MovieRankResponse> GetMovieRank(string movieName)
        {
            var response = await _movieRankObjectPersistenceModelRepository.GetMovieRank(movieName);

            var overallMovieRanking = Math.Round(response.Select(x => x.Ranking).Average());

            return new MovieRankResponse
            {
                MovieName = movieName,
                OverallRanking = overallMovieRanking
            };
        }
    }
}
