using Microsoft.Extensions.Logging;
using ElfmeterProjekt.ElfmeterProjektCore.ViewModels;
using ElfmeterProjekt.Lib.Interfaces;
using ElfmeterProjekt.Lib.Services;
using ElfmeterProjekt.ElfmeterProjektApp.Services;
using ElfmeterProjekt.ElfmeterProjektApp.Pages;
using CommunityToolkit.Maui;
using Syncfusion.Maui.Core.Hosting;

namespace ElfmeterProjekt.ElfmeterProjektApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<AddTeam>();
            builder.Services.AddSingleton<AddTeamViewModel>();

            builder.Services.AddSingleton<TeamList>();
            builder.Services.AddSingleton<TeamListViewModel>();

            

            string path = FileSystem.AppDataDirectory;
            
            string filename = "data.sqlite"; // Sqlite File for saving data
            string fullpath = System.IO.Path.Combine(path, filename);
            System.Diagnostics.Debug.WriteLine("Pfad:");
            System.Diagnostics.Debug.WriteLine(path);

            builder.Services.AddSingleton<IRepository>(new SqliteRepository(fullpath));
            builder.Services.AddSingleton<IAlertService, AlertService>();
#endif
            builder.ConfigureSyncfusionCore();
            return builder.Build();
        }
    }
}
