using Newtonsoft.Json;
using Services;
using Services.Models;

namespace Service.WebApi
{
    public class WeatherWebApiService : IWeather
    {
        private readonly HttpClient _httpClient;

        public WeatherWebApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResult> GetByCityWeather(string cityName)
        {
            var response = await _httpClient.GetAsync($"weather/{cityName}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<WeatherResult>(content);
                return result;
            }
            else
            {
                throw new HttpRequestException($"Error fetching weather data. Status code: {response.StatusCode}");
            }
        }

        public async Task<WeatherResult> GetByLocalWeather()
        {
            var response = await _httpClient.GetAsync($"weather/getLocal");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RootModel>(content);

                return result.Result; // Return the WeatherResult part of the response
            }
            else
            {
                throw new HttpRequestException($"Error fetching weather data. Status code: {response.StatusCode}");
            }
        }

    }
}
