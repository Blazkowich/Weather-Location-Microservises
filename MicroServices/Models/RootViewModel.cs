namespace WebApp.Models
{
    public class RootViewModel
    {
        public double TempCelsius { get; set; }
        public LocationViewModel Coord { get; set; }
    }

    public class LocationViewModel
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
