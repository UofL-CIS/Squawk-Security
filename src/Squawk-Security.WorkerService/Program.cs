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
                    services.AddTransient<IComplianceChecker, AnomalyBasedComplianceChecker>();
                    services.AddSingleton<ISniffingService, SharpPcapSniffingService>();
                    services.AddSingleton<IAnalysisService, BasicAnalysisService>();
                    services.AddSingleton<IPreventionService, DeAuthenticationPreventionService>();
                    services.AddSingleton<IReportingService, SerilogReportingService>();
                    services.AddHostedService<Worker>();
                });
    }
}
