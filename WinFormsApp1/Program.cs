using ClassLibrary1.Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Destructurama;

namespace WinFormsApp1;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var builder = new ConfigurationBuilder();
        BuildConfig(builder);
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build())
            .Destructure.UsingAttributes()
            .CreateLogger();

        //Logging Works
        Log.Logger.Information("Test");

        var services = new ServiceCollection();
        ConfigureServices(services);
        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        try
        {
            Application.Run(serviceProvider.GetRequiredService<Form1>());
        }
        catch (Exception ex)
        {
            Log.Logger.Fatal(ex, "Program crashed.");
        }
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        services.AddLogging(x => x.AddSerilog(Log.Logger, true));
        services.AddDbContext<MyAppContext>(opt => { opt.UseInMemoryDatabase("DBMemory"); opt.EnableSensitiveDataLogging(); }) ;
        services.AddScoped<Form1>();
    }

    private static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables();
    }
}