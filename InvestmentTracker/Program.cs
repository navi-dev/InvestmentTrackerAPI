using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace InvestmentTracker
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    //CreateWebHostBuilder(args).Build().Run();

        //}

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)


        //        .UseStartup<Startup>();

        public static void Main(string[] args) => BuildWebHost(args).Run();

        public static IWebHost BuildWebHost(string[] args) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    // find the shared folder in the parent folder
                    var appSettingsFolder = Path.Combine(env.ContentRootPath, "AppSettings");

                    var a = Path.Combine(appSettingsFolder, $"appsettings.{env.EnvironmentName}.json");

                    config.AddJsonFile("appsettings.json", optional: true)
                        .AddJsonFile(Path.Combine(appSettingsFolder, $"appsettings.{env.EnvironmentName}.json"), optional: true);
                        //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((ctx, log) => { /* elided for brevity */ })
                .UseDefaultServiceProvider((ctx, opts) => { /* elided for brevity */ })
                .UseStartup<Startup>()
                .Build();
    }
}
