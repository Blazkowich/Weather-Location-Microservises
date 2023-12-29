using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class RootModel
    {
        public WeatherResult Result { get; set; }
        public int Id { get; set; }
        public object Exception { get; set; }
        public int Status { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCompletedSuccessfully { get; set; }
        public int CreationOptions { get; set; }
        public object AsyncState { get; set; }
        public bool IsFaulted { get; set; }
    }

    public class WeatherResult
    {
        public string Name { get; set; }
        public SysModel Sys { get; set; }
        public long Dt { get; set; }
        public WindModel Wind { get; set; }
        public MainModel Main { get; set; }
        public List<WeatherModel> Weather { get; set; }
        public Location Coord { get; set; }
    }

    public class SysModel
    {
        public string Country { get; set; }
    }

    public class WindModel
    {
        public double Speed { get; set; }
    }

    public class MainModel
    {
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double TempCelsius { get; set; }
    }

    public class WeatherModel
    {
        public string Description { get; set; }
    }

    public class Location
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}

