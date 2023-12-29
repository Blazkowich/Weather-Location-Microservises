using Newtonsoft.Json;
using Services;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.WebApi
{
    public class LocationWebApiService : ILocation
    {
        private readonly HttpClient _httpClient;

        public LocationWebApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LatitudeLongtitude> GetCurrentLocationAsync()
        {
            var response = await _httpClient.GetAsync($"location/getlocation");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<LatitudeLongtitude>(content);
                return result;
            }
            else
            {
                throw new HttpRequestException($"Error fetching weather data. Status code: {response.StatusCode}");
            }
        }
    }
}
