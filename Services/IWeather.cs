using Services.Models;

namespace Services
{
    public interface IWeather
    {
        Task<WeatherResult> GetByCityWeather(string cityName);

        Task<WeatherResult> GetByLocalWeather();
    }
}
