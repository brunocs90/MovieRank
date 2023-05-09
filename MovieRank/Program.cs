using MovieRank.Libs.Mappers.DocumentModel;
using MovieRank.Libs.Mappers.LowLevelModel;
using MovieRank.Libs.Mappers.ObjectPersistenceModel;
using MovieRank.Libs.Repositories.DocumentModel;
using MovieRank.Libs.Repositories.LowLevelModel;
using MovieRank.Libs.Repositories.ObjectPersistenceModel;
using MovieRank.Services.DocumentModel;
using MovieRank.Services.LowLevelModel;
using MovieRank.Services.ObjectPersistenceModel;

namespace MovieRank
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Load configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            // Configure AWS services
            AwsServiceConfiguration.ConfigureAwsServices(builder.Services, configuration);

            // ObjectPersistenceModel
            builder.Services.AddSingleton<IMovieRankObjectPersistenceModelService, MovieRankObjectPersistenceModelService>();
            builder.Services.AddSingleton<IMovieRankObjectPersistenceModelRepository, MovieRankObjectPersistenceModelRepository>();
            builder.Services.AddSingleton<IMapperObjectPersistenceModel, MapperObjectPersistenceModel>();

            // DocumentModel
            builder.Services.AddSingleton<IMovieRankDocumentModelService, MovieRankDocumentModelService>();
            builder.Services.AddSingleton<IMovieRankDocumentModelRepository, MovieRankDocumentModelRepository>();
            builder.Services.AddSingleton<IMapperDocumentModel, MapperDocumentModel>();

            // LowLevelModel
            builder.Services.AddSingleton<IMovieRankLowLevelModelService, MovieRankLowLevelModelService>();
            builder.Services.AddSingleton<IMovieRankLowLevelModelRepository, MovieRankLowLevelModelRepository>();
            builder.Services.AddSingleton<IMapperLowLevelModel, MapperLowLevelModel>();
            builder.Services.AddSingleton<ISetupService, SetupService>();

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
        }
    }
}