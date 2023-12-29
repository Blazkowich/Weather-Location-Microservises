using Services.Models;

namespace Services
{
    public interface ILocation
    {
        Task<LatitudeLongtitude> GetCurrentLocationAsync();
    }
}
