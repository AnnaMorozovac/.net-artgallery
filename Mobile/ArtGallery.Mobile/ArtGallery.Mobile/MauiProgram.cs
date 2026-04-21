using Microsoft.Extensions.Logging;
using ArtGallery.Mobile.Services;
using ArtGallery.Mobile.ViewModels;
using ArtGallery.Mobile.Views;

namespace ArtGallery.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            string baseUrl;
#if ANDROID
            baseUrl = "http://10.0.2.2:7286/";
#else
            baseUrl = "http://localhost:7286/";
#endif
            builder.Services.AddSingleton(new HttpClient 
            { 
                BaseAddress = new Uri(baseUrl) 
            });

            builder.Services.AddSingleton<ApiService>();


            builder.Services.AddTransient<ArtistListViewModel>();
            builder.Services.AddTransient<ArtworkListViewModel>();
            builder.Services.AddTransient<CategoryListViewModel>();
            builder.Services.AddTransient<ExhibitionListViewModel>();

            builder.Services.AddTransient<ArtistListPage>();
            builder.Services.AddTransient<ArtworkListPage>();
            builder.Services.AddTransient<CategoryListPage>();
            builder.Services.AddTransient<ExhibitionListPage>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
