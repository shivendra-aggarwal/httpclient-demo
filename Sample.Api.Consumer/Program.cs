using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Sample.Api.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sample Api Consumer";

            new WebHostBuilder()
                .CaptureStartupErrors(true)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddEnvironmentVariables();

                })
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                //.UseIISIntegration()
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}
