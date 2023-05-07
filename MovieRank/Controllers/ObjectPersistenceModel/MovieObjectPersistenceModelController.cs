using Microsoft.AspNetCore.Mvc;
using MovieRank.Contracts;
using MovieRank.Services.ObjectPersistenceModel;

namespace MovieRank.Controllers.ObjectPersistenceModel
{

    [Route("moviesObjectPersistenceModel")]
    public class MovieObjectPersistenceModelController : Controller
    {

        private readonly IMovieRankObjectPersistenceModelService _movieRankObjectPersistenceModelService;

        public MovieObjectPersistenceModelController(IMovieRankObjectPersistenceModelService movieRankObjectPersistenceModelService)
        {
            _movieRankObjectPersistenceModelService = movieRankObjectPersistenceModelService;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var results = await _movieRankObjectPersistenceModelService.GetAllItemsFromDatabase();

            return results;
        }

        [HttpGet]
        [Route("{userId}/{movieName}")]
        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var result = await _movieRankObjectPersistenceModelService.GetMovie(userId, movieName);

            return result;
        }

        [HttpGet]
        [Route("user/{userId}/rankedMovies/{movieName}")]
        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var results = await _movieRankObjectPersistenceModelService.GetUsersRankedMoviesByMovieTitle(userId, movieName);

            return results;
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> AddMovie(int userId, [FromBody] MovieRankRequest movieRankRequest)
        {
            await _movieRankObjectPersistenceModelService.AddMovie(userId, movieRankRequest);

            return Ok();
        }

        [HttpPatch]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateMovie(int userId, [FromBody] MovieUpdateRequest request)
        {
            await _movieRankObjectPersistenceModelService.UpdateMovie(userId, request);

            return Ok();
        }

        [HttpGet]
        [Route("{movieName}/ranking")]
        public async Task<MovieRankResponse> GetMoviesRanking(string movieName)
        {
            var result = await _movieRankObjectPersistenceModelService.GetMovieRank(movieName);

            return result;
        }
    }
}
