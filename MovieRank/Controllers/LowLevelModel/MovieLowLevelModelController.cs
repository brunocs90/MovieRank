using Microsoft.AspNetCore.Mvc;
using MovieRank.Contracts;
using MovieRank.Services.LowLevelModel;

namespace MovieRank.Controllers.LowLevelModel
{

    [Route("moviesLowLevelModel")]
    public class MovieLowLevelModelController : Controller
    {

        private readonly IMovieRankLowLevelModelService _movieRankLowLevelModelService;

        public MovieLowLevelModelController(IMovieRankLowLevelModelService movieRankLowLevelModelService)
        {
            _movieRankLowLevelModelService = movieRankLowLevelModelService;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var results = await _movieRankLowLevelModelService.GetAllItemsFromDatabase();

            return results;
        }

        [HttpGet]
        [Route("{userId}/{movieName}")]
        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var result = await _movieRankLowLevelModelService.GetMovie(userId, movieName);

            return result;
        }

        [HttpGet]
        [Route("user/{userId}/rankedMovies/{movieName}")]
        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var results = await _movieRankLowLevelModelService.GetUsersRankedMoviesByMovieTitle(userId, movieName);

            return results;
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> AddMovie(int userId, [FromBody] MovieRankRequest movieRankRequest)
        {
            await _movieRankLowLevelModelService.AddMovie(userId, movieRankRequest);

            return Ok();
        }

        [HttpPatch]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateMovie(int userId, [FromBody] MovieUpdateRequest request)
        {
            await _movieRankLowLevelModelService.UpdateMovie(userId, request);

            return Ok();
        }

        [HttpGet]
        [Route("{movieName}/ranking")]
        public async Task<MovieRankResponse> GetMoviesRanking(string movieName)
        {
            var result = await _movieRankLowLevelModelService.GetMovieRank(movieName);

            return result;
        }
    }
}
