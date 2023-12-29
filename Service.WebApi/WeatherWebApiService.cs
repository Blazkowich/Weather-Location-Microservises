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

        public async Task<RootModel> GetByCityWeather(string cityName)
        {
            // Assume the weather information is retrieved through an API endpoint
            var response = await _httpClient.GetAsync($"weather/{cityName}");

            if (response.IsSuccessStatusCode)
            {
                // Parse and return the response content as RootModel
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RootModel>(content);
                return result;
            }
            else
            {
                // Handle non-success status code, log, or throw an exception
                throw new HttpRequestException($"Error fetching weather data. Status code: {response.StatusCode}");
            }
        }
    }
}
