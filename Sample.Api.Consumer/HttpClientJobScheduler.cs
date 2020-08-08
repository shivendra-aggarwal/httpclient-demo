using Coravel.Invocable;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sample.Api.Consumer
{
    public class HttpClientJobScheduler : IInvocable
    {
        private HttpClient _httpClient;

        public HttpClientJobScheduler()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5002");
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
