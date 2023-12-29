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
            var response = await _httpClient.GetAsync($"weather/{cityName}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RootModel>(content);
                return result;
            }
            else
            {
                throw new HttpRequestException($"Error fetching weather data. Status code: {response.StatusCode}");
            }
        }

        public async Task<RootModel> GetByLatitudeAndLongtitudeWeather(string latitude, string longitude)
        {
            var response = await _httpClient.GetAsync($"weather/{latitude}/{longitude}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RootModel>(content);
                return result;
            }
            else
            {
                throw new HttpRequestException($"Error fetching weather data. Status code: {response.StatusCode}");
            }
        }
    }
}
