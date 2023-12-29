using Microsoft.AspNetCore.Mvc;
using Service.WorkPlace;
using Services;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeather _weather;

        public WeatherForecastController(IWeather weather)
        {
            _weather = weather;
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
    }
}
