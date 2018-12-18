using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace AlphaParAPI
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                .UseIISIntegration()
                .Build();

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .ReadFrom.Configuration(Configuration)
                .WriteTo.Console()
                .WriteTo.MSSqlServer(Configuration.GetConnectionString("AlphaParLog"), "LogSecu", autoCreateSqlTable: true)
                .WriteTo.File("Logs/AlphaParLog-.txt",
                    outputTemplate: "{Timestamp: yyyy-MM-dd HH:mm:ss} {Message:lj}{NewLine}{Properties:j}",
                    rollingInterval: RollingInterval.Hour)
                .CreateLogger();

            try
            {
                BuildWebHost(args).Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host could not start because of an unknown error");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}