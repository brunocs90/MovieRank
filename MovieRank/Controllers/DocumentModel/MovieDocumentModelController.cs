using Microsoft.AspNetCore.Mvc;
using MovieRank.Contracts;
using MovieRank.Services;

namespace MovieRank.Controllers.DocumentModel
{

    [Route("moviesDocumentModel")]
    public class MovieDocumentModelController : Controller
    {

        private readonly IMovieRankDocumentModelService _movieRankDocumentModelService;

        public MovieDocumentModelController(IMovieRankDocumentModelService movieRankDocumentModelService)
        {
            _movieRankDocumentModelService = movieRankDocumentModelService;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var results = await _movieRankDocumentModelService.GetAllItemsFromDatabase();

            return results;
        }

        [HttpGet]
        [Route("{userId}/{movieName}")]
        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var result = await _movieRankDocumentModelService.GetMovie(userId, movieName);

            return result;
        }

        [HttpGet]
        [Route("user/{userId}/rankedMovies/{movieName}")]
        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var results = await _movieRankDocumentModelService.GetUsersRankedMoviesByMovieTitle(userId, movieName);

            return results;
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> AddMovie(int userId, [FromBody] MovieRankRequest movieRankRequest)
        {
            await _movieRankDocumentModelService.AddMovie(userId, movieRankRequest);

            return Ok();
        }

        [HttpPatch]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateMovie(int userId, [FromBody] MovieUpdateRequest request)
        {
            await _movieRankDocumentModelService.UpdateMovie(userId, request);

            return Ok();
        }

        [HttpGet]
        [Route("{movieName}/ranking")]
        public async Task<MovieRankResponse> GetMoviesRanking(string movieName)
        {
            var result = await _movieRankDocumentModelService.GetMovieRank(movieName);

            return result;
        }
    }
}
