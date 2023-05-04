using Microsoft.AspNetCore.Mvc;
using MovieRank.Contracts;
using MovieRank.Services;

namespace MovieRank.Controllers
{

    [Route("movies")]
    public class MovieController : Controller
    {

        private readonly IMovieRankService _movieRankService;

        public MovieController(IMovieRankService movieRankService)
        {
            _movieRankService = movieRankService;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var results = await _movieRankService.GetAllItemsFromDatabase();

            return results;
        }
    }
}
