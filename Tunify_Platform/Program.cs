using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            var ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<TunifyDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));
           
            builder.Services.AddTransient<IUser, UserServices>();
            builder.Services.AddTransient<ISong, SongServices>();
            builder.Services.AddTransient<IPlayList, PlaylistsServices>();
            builder.Services.AddTransient<IArtists, ArtistsServices>();

            builder.Services.AddSwaggerGen(
              option =>
              {
                  option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                  {
                      Title = "Tunify API",
                      Version = "v1",
                      Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                  });
              }
              );

            var app = builder.Build();
            app.UseSwagger(
                         options =>
                         {
                             options.RouteTemplate = "api/{documentName}/swagger.json";
                         }
                         );


            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = "";
            });

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
           
        }
    }
}
