using Amazon.DynamoDBv2.Model;
using MovieRank.Contracts;

namespace MovieRank.Libs.Mappers.LowLevelModel
{
    public interface IMapperLowLevelModel
    {
        IEnumerable<MovieResponse> ToMovieContract(ScanResponse response);

        MovieResponse ToMovieContract(GetItemResponse response);

        IEnumerable<MovieResponse> ToMovieContract(QueryResponse response);
    }
}
