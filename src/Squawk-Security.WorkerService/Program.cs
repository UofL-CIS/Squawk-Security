using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Squawk_Security.ClassLibrary;
using Squawk_Security.ClassLibrary.Models;
using Squawk_Security.ClassLibrary.Services;

namespace Squawk_Security.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Read config from appsettings.json
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Use the previous config to build the logger
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try
            {
                Log.Information("Application starting");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Application failed to start");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog(Log.Logger)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<IComplianceChecker, RuleBasedComplianceChecker>();
                    services.AddScoped<ISniffingService, SharpPcapSniffingService>();
                    services.AddScoped<IAnalysisService, BasicAnalysisService>();
                    services.AddScoped<IPreventionService, DeAuthenticationPreventionService>();
                    services.AddScoped<IReportingService, SerilogReportingService>();
                });
    }
}
