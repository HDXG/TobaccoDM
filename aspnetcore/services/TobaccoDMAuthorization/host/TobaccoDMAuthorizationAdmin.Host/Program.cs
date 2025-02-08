using Serilog;
using Serilog.Events;
using TobaccoDMAuthorization;
using TobaccoDMAuthorization.EntityFrameworkCore;

namespace TobaccoDMAuthorizationAdmin;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Async(c => c.File(path:"Logs/logs.txt", rollingInterval:RollingInterval.Hour, retainedFileCountLimit: null))
            .WriteTo.Async(c => c.Console())
            .CreateBootstrapLogger();

        try
        {
            Log.Information("TobaccoDMAuthorization web host.");
            var builder = WebApplication.CreateBuilder(args);
            

            #region aspire
            builder.AddServiceDefaults();
            builder.AddMySqlDbContext<TobaccoDMAuthorizationDbContext>(TobaccoDMAuthorizationDomainOptions.ConnectionStringName, options =>
            {
                options.DisableRetry = true;
            });
            #endregion
            
            builder.Host
                .AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog((context, services, loggerConfiguration) =>
                {
                    loggerConfiguration
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                    .Enrich.FromLogContext()
                    .WriteTo.Async(c => c.File(path:"Logs/logs.txt", rollingInterval:RollingInterval.Hour, retainedFileCountLimit: null))
                    .WriteTo.Async(c => c.Console())
                    .WriteTo.Async(c => c.OpenTelemetry());
                });
            
            // Minimal Apis
            builder.Services.AddEndpointsApiExplorer();
            
            await builder.AddApplicationAsync<TobaccoDMAuthorizationAdminHostModule>();
            
            var app = builder.Build();

            // Minimal Apis
            app.MapTobaccoDmAuthorizationAdminMinimalApis();

            await app.InitializeApplicationAsync();
            await app.RunAsync();
            
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "TobaccoDMAuthorization Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
