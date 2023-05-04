using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using MovieRank.Libs.Mappers;
using MovieRank.Libs.Repositories;
using MovieRank.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddDefaultAWSOptions(
    new AWSOptions
    {
        Region = RegionEndpoint.GetBySystemName("us-west-2")
    });

builder.Services.AddSingleton<IMovieRankService, MovieRankService>();
builder.Services.AddSingleton<IMovieRankRepository, MovieRankRepository>();
builder.Services.AddSingleton<IMapper, Mapper>();


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
