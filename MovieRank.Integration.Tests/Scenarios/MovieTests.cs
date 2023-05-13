using MovieRank.Contracts;
using MovieRank.Integration.Tests.Setup;
using MovieRank.Libs.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using Xunit;

namespace MovieRank.Integration.Tests.Scenarios
{
    [Collection("api")]
    public class MovieTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        readonly HttpClient _client;
        private readonly string DEFAULT_ROUTE = "moviesObjectPersistenceModel";

        public MovieTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AddMovieRankDataReturnsOkStatus()
        {
            // Arrange
            const int userId = 1;

            // Act
            var response = await AddMovieRankData(userId);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetAllItemsFromDatabaseReturnsNotNullMovieResponse()
        {
            // Arrange
            const int userId = 2;

            await AddMovieRankData(userId);

            // Act
            var response = await _client.GetAsync(DEFAULT_ROUTE);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MovieResponse[]>(content);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetMovieReturnsExpectedMovieName()
        {
            // Arrange
            const int userId = 3;
            const string movieName = "Test-GetMovieBack";

            await AddMovieRankData(userId, movieName);

            // Act
            var response = await _client.GetAsync($"{DEFAULT_ROUTE}/{userId}/{movieName}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MovieResponse>(content);

            // Assert
            Assert.Equal(movieName, result?.MovieName);
        }

        [Fact]
        public async Task UpdateMovieReturnsUpdatedMovieRankValue()
        {
            // Arrange
            const int userId = 4;
            const string movieName = "Test-UpdateMovie";
            const int ranking = 10;

            await AddMovieRankData(userId, movieName);

            var updateMovie = new MovieUpdateRequest
            {
                MovieName = movieName,
                Ranking = ranking
            };

            var json = JsonConvert.SerializeObject(updateMovie);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            await _client.PatchAsync($"{DEFAULT_ROUTE}/{userId}", stringContent);
            var response = await _client.GetAsync($"{DEFAULT_ROUTE}/{userId}/{movieName}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MovieResponse>(content);

            // Assert
            Assert.Equal(ranking, result?.Ranking);
        }

        [Fact]
        public async Task GetMoviesRankingReturnsAnOverallMovieRanking()
        {
            // Arrange
            const int userId = 5;
            const string movieName = "Test-GetMovieOverallRanking";
            await AddMovieRankData(userId, movieName);

            // Act
            var response = await _client.GetAsync($"{DEFAULT_ROUTE}/{movieName}/ranking");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<MovieRankResponse>(content);

            // Assert
            Assert.NotNull(result);
        }

        private async Task<HttpResponseMessage> AddMovieRankData(int testUserId, string movieName = "test-MovieName")
        {
            var movieDbData = new MovieDb
            {
                UserId = testUserId,
                MovieName = movieName,
                Description = "test-Description",
                Actors = new List<string>
                {
                    "testUser1",
                    "testUser2"
                },
                RankedDateTime = "5/10/2018 6:17:17 PM",
                Ranking = 4
            };

            var json = JsonConvert.SerializeObject(movieDbData);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            return await _client.PostAsync($"{DEFAULT_ROUTE}/{testUserId}", stringContent);
        }
    }
}
