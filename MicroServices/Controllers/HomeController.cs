using MicroServices.Models;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;
using Services.Models;
using WebApp.Models;

namespace MicroServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeather _weather;

        public HomeController(ILogger<HomeController> logger, IWeather weather)
        {
            _logger = logger;
            _weather = weather;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            try
            {
                var weatherResult = await _weather.GetByLocalWeather();

                return View("Index", weatherResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
