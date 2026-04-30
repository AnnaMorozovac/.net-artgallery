
using ArtGallery.BLL.Profiles;
using ArtGallery.DAL;
using ArtGallery.DAL.Repositories;
using ArtistGallery.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ArtGallery.BLL.Services;

namespace ArtGallery.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddAutoMapper(typeof(ArtGallery.BLL.Profiles.MappingProfile).Assembly);


            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

           builder.Services.AddScoped<IArtistService, ArtistService>();
           builder.Services.AddScoped<IArtworkService, ArtworkService>();
           builder.Services.AddScoped<ICategoryService, CategoryService>();
           builder.Services.AddScoped<IExhibitionService, ExhibitionService>();
           builder.Services.AddScoped<IUserService, UserService>();
           builder.Services.AddScoped<IFavoriteService, FavoriteService>();

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthorization();

            var app = builder.Build();

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
