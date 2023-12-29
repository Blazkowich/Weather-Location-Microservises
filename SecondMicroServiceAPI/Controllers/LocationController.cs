using Microsoft.AspNetCore.Mvc;
using Services;

namespace SecondMicroServiceAPI.Controllers
{
    [ApiController]
    [Route("api/location")]
    public class LocationController : ControllerBase
    {
        private readonly ILocation _location;

        public LocationController(ILocation location)
        {
            this._location = location;
        }

        [HttpGet("getlocation")]
        public IActionResult GetLocation() 
        {
            try
            {
                var result = _location.GetCurrentLocationAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
