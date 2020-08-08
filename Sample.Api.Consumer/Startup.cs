using Coravel;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace Sample.Api.Consumer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScheduler();
            services.AddTransient<HttpClientJobScheduler>();
            services.AddTransient<HttpClient>();
            services.AddHttpClient("schedulingJob", c =>
            {
                c.BaseAddress = new Uri("http://localhost:5002");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

        }

        public void Configure(IApplicationBuilder app)
        {
            // Commenting below configuration on temporary basis
            app.ApplicationServices.UseScheduler(scheduler =>
            {
                scheduler.Schedule<HttpClientJobScheduler>().EveryTenSeconds();
            });

            
        }
    }
}
