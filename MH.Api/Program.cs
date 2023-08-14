using MH.Domain.Constant;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace MH.Api;

public class Program
{
    public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
            true)
        .Build();

    public static void Main(string[] args)
    {
        try
        {
            var connectionString = Configuration.GetConnectionString(ConfigOptions.DbConnName);
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.MSSqlServer(
                    connectionString,
                    new MSSqlServerSinkOptions { TableName = "Log" },
                    null,
                    null,
                    LogEventLevel.Information
                ).CreateLogger();


            Log.Information("Application starting....");
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseConfiguration(Configuration);
            });
    }
    //.UseSerilog();
}