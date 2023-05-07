using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using MovieRank.Libs.Mappers.DocumentModel;
using MovieRank.Libs.Mappers.ObjectPersistenceModel;
using MovieRank.Libs.Repositories.DocumentModel;
using MovieRank.Libs.Repositories.ObjectPersistenceModel;
using MovieRank.Services;
using MovieRank.Services.ObjectPersistenceModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddDefaultAWSOptions(
    new AWSOptions
    {
        Region = RegionEndpoint.GetBySystemName("us-west-2")
    });

///ObjectPersistenceModel
builder.Services.AddSingleton<IMovieRankObjectPersistenceModelService, MovieRankObjectPersistenceModelService>();
builder.Services.AddSingleton<IMovieRankObjectPersistenceModelRepository, MovieRankObjectPersistenceModelRepository>();
builder.Services.AddSingleton<IMapperObjectPersistenceModel, MapperObjectPersistenceModel>();

///DocumentModel
builder.Services.AddSingleton<IMovieRankDocumentModelService, MovieRankDocumentModelService>();
builder.Services.AddSingleton<IMovieRankDocumentModelRepository, MovieRankDocumentModelRepository>();
builder.Services.AddSingleton<IMapperDocumentModel, MapperDocumentModel>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
