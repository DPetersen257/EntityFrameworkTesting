using ClassLibrary1.Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Destructurama;
using ClassLibrary1;
using System.Linq;

namespace WinFormsApp1;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var builder = BuildConfig();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder)
            .Enrich.FromLogContext()
            .Destructure.UsingAttributes()
            .CreateLogger();

        //Logging Works
        Log.Logger.Information("Test");

        var services = new ServiceCollection();
        ConfigureServices(services);

        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        ServiceProvider = serviceProvider;

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
        services.AddSingleton<Form1>();
        services.AddTransient<IDoSomethingClass, DoSomethingClass>();
    }

    private static IConfiguration BuildConfig()
    {
        var builder = new ConfigurationBuilder();

        builder.SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables();

        return builder.Build();
    }
}