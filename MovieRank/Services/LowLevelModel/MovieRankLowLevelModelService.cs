using MovieRank.Contracts;
using MovieRank.Libs.Mappers.LowLevelModel;
using MovieRank.Libs.Repositories.LowLevelModel;

namespace MovieRank.Services.LowLevelModel
{
    public class MovieRankLowLevelModelService : IMovieRankLowLevelModelService
    {
        private readonly IMovieRankLowLevelModelRepository _movieRankDocumentModelRepository;
        private readonly IMapperLowLevelModel _mapperLowLevelModel;

        public MovieRankLowLevelModelService(IMovieRankLowLevelModelRepository movieRankDocumentModelRepository, IMapperLowLevelModel mapLowLevelModel)
        {
            _movieRankDocumentModelRepository = movieRankDocumentModelRepository;
            _mapperLowLevelModel = mapLowLevelModel;
        }

        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var response = await _movieRankDocumentModelRepository.GetAllItems();

            return _mapperLowLevelModel.ToMovieContract(response);
        }

        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var response = await _movieRankDocumentModelRepository.GetMovie(userId, movieName);

            return _mapperLowLevelModel.ToMovieContract(response);
        }

        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var response = await _movieRankDocumentModelRepository.GetUsersRankedMoviesByMovieTitle(userId, movieName);

            return _mapperLowLevelModel.ToMovieContract(response);
        }

        public async Task AddMovie(int userId, MovieRankRequest movieRankRequest)
        {
            await _movieRankDocumentModelRepository.AddMovie(userId, movieRankRequest);
        }

        public async Task UpdateMovie(int userId, MovieUpdateRequest request)
        {
            await _movieRankDocumentModelRepository.UpdateMovie(userId, request);
        }

        public async Task<MovieRankResponse> GetMovieRank(string movieName)
        {
            var response = await _movieRankDocumentModelRepository.GetMovieRank(movieName);

            var overallMovieRanking = Math.Round(response.Items.Select(item => Convert.ToInt32(item["Ranking"].N)).Average());

            return new MovieRankResponse
            {
                MovieName = movieName,
                OverallRanking = overallMovieRanking
            };
        }
    }
}
