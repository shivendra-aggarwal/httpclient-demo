using Coravel.Invocable;
using Newtonsoft.Json;
using Sample.Api.Consumer.Counter;
using Sample.Api.Consumer.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sample.Api.Consumer
{
    public class HttpClientJobScheduler : IInvocable
    {
        private HttpClient _httpClient;
        private readonly ICounter _counter;
        public HttpClientJobScheduler(ICounter counter)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5002");
            _counter = counter;
        }

        public async Task Invoke()
        {
            var response = await _httpClient.GetAsync("weatherforecast");

            if (response.IsSuccessStatusCode)
            {
                var weatherForeCastDto = JsonConvert.DeserializeObject<IEnumerable<WeatherForecastDto>>(await response.Content.ReadAsStringAsync());
                await _counter.IncrementByOne();
                Console.WriteLine($"Iteration: {await _counter.GetCount()}");
                Console.WriteLine($"Success: {response}");
                Console.WriteLine($"Result: {JsonConvert.SerializeObject(weatherForeCastDto)}");
                Console.WriteLine($"...............................................................................................................................");
            }
            else
            {
                Console.WriteLine($"Error while polling url...");
            }
        }
    }
}
