using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class GoogleMapsResponse
    {
        public string Status { get; set; } = string.Empty;
        public List<GoogleMapsResult> Results { get; set; }
    }

    public class GoogleMapsResult
    {
        public GoogleMapsGeometry Geometry { get; set; }
    }

    public class GoogleMapsGeometry
    {
        public GoogleMapsLocation Location { get; set; }
    }

    public class GoogleMapsLocation
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
