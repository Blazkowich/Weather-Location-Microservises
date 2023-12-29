using Microsoft.AspNetCore.Mvc;
using Service.WorkPlace;
using Services;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeather _weather;
        private readonly ILocation _location;

        public WeatherController(IWeather weather, ILocation location)
        {
            _weather = weather;
            _location = location;
        }

        [HttpGet("getbycity/{cityName}")]
        public ActionResult GetWeather(string cityName)
        {
            try
            {
                var result = _weather.GetByCityWeather(cityName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("getLocal")]
        public async Task<ActionResult> GetWeatherByLatAndLong()
        {
            try
            {
                var result = _weather.GetByLocalWeather();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
