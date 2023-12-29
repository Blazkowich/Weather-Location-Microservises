using Newtonsoft.Json;
using Services;
using Services.Models;
using System.Net;

namespace Service.WorkPlace
{
    public class WeatherWorkPlace : IWeather
    {
        private readonly string apiKey = "42130e33d0201d195e4935e0c182a513";
        private readonly ILocation _location;

        public WeatherWorkPlace(ILocation location)
        {
            _location = location;
        }

        public async Task<WeatherResult> GetByCityWeather(string cityName)
        {
            using var webClient = new WebClient();

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}";

            try
            {
                var json = webClient.DownloadString(url);

                var result = JsonConvert.DeserializeObject<WeatherResult>(json);

                ConvertTemperatureToCelsius(result);

                return result;
            }
            catch (WebException webException)
            {
                if (webException.Response is HttpWebResponse httpResponse)
                {
                    if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        return new WeatherResult
                        {
                            Name = "City Not Found",
                        };
                    }
                }
                throw;
            }
        }


        public async Task<WeatherResult> GetByLocalWeather()
        {
            using var webClient = new WebClient();
            var location = await _location.GetCurrentLocationAsync();

            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={location.Lat}&lon={location.Lon}&appid={apiKey}";

            try
            {
                var json = webClient.DownloadString(url);

                var result = JsonConvert.DeserializeObject<WeatherResult>(json);

                ConvertTemperatureToCelsius(result);

                return result;
            }
            catch (WebException webException)
            {
                if (webException.Response is HttpWebResponse httpResponse)
                {
                    if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        return new WeatherResult
                        {
                            Name = "Location Not Found",
                        };
                    }
                }
                throw;
            }
        }

        private void ConvertTemperatureToCelsius(WeatherResult rootModel)
        {
            if (rootModel != null && rootModel.Main != null)
            {
                rootModel.Main.TempCelsius = ConvertKelvinToCelsius(rootModel.Main.Temp);
            }
        }

        private double ConvertKelvinToCelsius(double kelvin)
        {
            return Math.Round(kelvin - 273.15, 1);
        }
    }
}
