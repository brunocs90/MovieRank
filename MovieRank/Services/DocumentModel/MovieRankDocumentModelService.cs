using MovieRank.Contracts;
using MovieRank.Libs.Mappers.DocumentModel;
using MovieRank.Libs.Repositories.DocumentModel;

namespace MovieRank.Services
{
    public class MovieRankDocumentModelService : IMovieRankDocumentModelService
    {
        private readonly IMovieRankDocumentModelRepository _movieRankDocumentModelRepository;
        private readonly IMapperDocumentModel _mapperDocumentModel;

        public MovieRankDocumentModelService(IMovieRankDocumentModelRepository movieRankDocumentModelRepository, IMapperDocumentModel mapDocumentModel)
        {
            _movieRankDocumentModelRepository = movieRankDocumentModelRepository;
            _mapperDocumentModel = mapDocumentModel;
        }

        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var response = await _movieRankDocumentModelRepository.GetAllItems();

            return _mapperDocumentModel.ToMovieContract(response);
        }

        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var response = await _movieRankDocumentModelRepository.GetMovie(userId, movieName);

            return _mapperDocumentModel.ToMovieContract(response);
        }

        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var response = await _movieRankDocumentModelRepository.GetUsersRankedMoviesByMovieTitle(userId, movieName);

            return _mapperDocumentModel.ToMovieContract(response);
        }

        public async Task AddMovie(int userId, MovieRankRequest addRequest)
        {
            var documentModel = _mapperDocumentModel.ToDocumentModel(userId, addRequest);

            await _movieRankDocumentModelRepository.AddMovie(documentModel);
        }

        public async Task UpdateMovie(int userId, MovieUpdateRequest movieUpdateRequest)
        {
            var movieResponse = await GetMovie(userId, movieUpdateRequest.MovieName);

            var documentModel = _mapperDocumentModel.ToDocumentModel(userId, movieResponse, movieUpdateRequest);

            await _movieRankDocumentModelRepository.UpdateMovie(documentModel);
        }

        public async Task<MovieRankResponse> GetMovieRank(string movieName)
        {
            var response = await _movieRankDocumentModelRepository.GetMovieRank(movieName);

            var overallMovieRanking = Math.Round(response.Select(r => r["Ranking"].AsInt()).Average());

            return new MovieRankResponse
            {
                MovieName = movieName,
                OverallRanking = overallMovieRanking
            };
        }
    }
}
