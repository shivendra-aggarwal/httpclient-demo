using Coravel.Invocable;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sample.Api.Consumer
{
    public class HttpClientFactoryJobScheduler : IInvocable
    {
        private HttpClient _httpClient;

        public HttpClientFactoryJobScheduler(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("schedulingJob");
        }

        public async Task Invoke()
        {
            var response = await _httpClient.GetAsync("weatherforecast");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Success: {response}");
            }
            else
            {
                Console.WriteLine($"Error while polling url...");
            }
        }
    }
}
