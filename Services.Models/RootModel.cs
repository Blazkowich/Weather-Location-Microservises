using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class RootModel
    {
        public string Name { get; set; } = string.Empty;

        public SysModel Sys { get; set; }

        public double Dt { get; set; }

        public WindModel Wind { get; set; }

        public MainModel Main { get; set; }

        public List<WeatherModel> Weather { get; set; }

        public LocationModel Coord { get; set; }
    }

    public class SysModel
    {
        public string Country { get; set; } = string.Empty;
    }

    public class WindModel
    {
        public double Speed { get; set; }
    }

    public class MainModel
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public double Humidity { get; set; }

        public double TempCelsius { get; set; }
    }

    public class WeatherModel
    {
        public string Description { get; set; } = string.Empty;
    }

    public class LocationModel
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}

