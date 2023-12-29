using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IWeather
    {
        Task<RootModel> GetByCityWeather(string cityName);
    }
}
