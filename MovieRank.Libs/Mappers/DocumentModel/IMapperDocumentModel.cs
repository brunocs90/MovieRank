﻿using Amazon.DynamoDBv2.DocumentModel;
using MovieRank.Contracts;

namespace MovieRank.Libs.Mappers.DocumentModel
{
    public interface IMapperDocumentModel
    {
        IEnumerable<MovieResponse> ToMovieContract(IEnumerable<Document> items);
        MovieResponse ToMovieContract(Document movie);
        Document ToDocumentModel(int userId, MovieRankRequest addRequest);
        Document ToDocumentModel(int userId, MovieResponse movieResponse, MovieUpdateRequest movieUpdateRequest);
    }
}
