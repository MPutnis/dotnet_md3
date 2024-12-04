using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using StudyClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace MD3
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
            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath("C:\\Temp")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (connectionString == null)
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }

            connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString));
            
          
            

            
            

            //builder.Services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudyDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            // Registering ViewModels and Views
           
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
