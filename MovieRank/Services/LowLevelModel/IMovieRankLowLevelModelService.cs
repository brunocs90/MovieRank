﻿using MovieRank.Contracts;

namespace MovieRank.Services.LowLevelModel
{
    public interface IMovieRankLowLevelModelService
    {
        Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase();

        Task<MovieResponse> GetMovie(int userId, string movieName);

        Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName);

        Task AddMovie(int userId, MovieRankRequest movieRankRequest);

        Task UpdateMovie(int userId, MovieUpdateRequest request);

        Task<MovieRankResponse> GetMovieRank(string movieName);
    }
}
