//using Microsoft.AspNetCore.Mvc;
//using Services;
//using WebApp.Models;

//namespace WebApp.Controllers
//{
//    public class LocalWeatherController : Controller
//    {
//        private readonly IWeather _weather;
//        private readonly ILocation _location;

//        public LocalWeatherController(IWeather weather, ILocation location)
//        {
//            _weather = weather;
//            _location = location;
//        }
//        [HttpGet]
//        public async Task<IActionResult> Index()
//        {
//            var weatherResult = await _weather.GetByLocalWeather();
//            try
//            {
//                var result = new RootViewModel
//                {
//                    Name = weatherResult.Name,
//                    Sys = new SysModel
//                    {
//                        Country = weatherResult.Sys.Country
//                    },
//                    Dt = weatherResult.Dt,
//                    Wind = new WindModel
//                    {
//                        Speed = weatherResult.Wind.Speed,
//                    },
//                    Main = new MainModel
//                    {
//                        Temp = weatherResult.Main.Temp,
//                        Pressure = weatherResult.Main.Pressure,
//                        Humidity = weatherResult.Main.Humidity,
//                        TempCelsius = weatherResult.Main.TempCelsius,
//                    },
//                    Weather = weatherResult.Weather.Select(w => new WeatherModel
//                    {
//                        Description = w.Description
//                    }).ToList(),
//                    Coord = new Location
//                    {
//                        Lat = weatherResult.Coord.Lat,
//                        Lon = weatherResult.Coord.Lon
//                    }
//                };



//                return View("Index", result);

//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"An error occurred: {ex.Message}");
//            }
//        }

//    }
//}
