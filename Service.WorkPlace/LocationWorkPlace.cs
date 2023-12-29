using Services.Models;
using Services;
using Newtonsoft.Json;
using System.Net;

namespace Service.WorkPlace
{
    public class LocationWorkPlace : ILocation
    {
        private readonly string apiKey = "b35eddc46ec94be8af3113dfc68922b8";

        public async Task<LatitudeLongtitude> GetCurrentLocationAsync()
        {
            using var webClient = new WebClient();

            var ipInfo = new LatitudeLongtitude();

            var url = "https://ipinfo.io/5.152.105.123?token=c45a0cd293ae24";

            try
            {
                var json = webClient.DownloadString(url);

                var result = JsonConvert.DeserializeObject<LatitudeLongtitude>(json);

                if (!string.IsNullOrEmpty(result.Loc))
                {
                    var coordinates = result.Loc.Split(',');
                    if (coordinates.Length == 2)
                    {
                        result.Lat = double.Parse(coordinates[0]);
                        result.Lon = double.Parse(coordinates[1]);
                    }
                }

                return result;
            }
            catch (WebException webException)
            {
                if (webException.Response is HttpWebResponse httpResponse)
                {
                    if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        return new LatitudeLongtitude
                        {
                            Loc = "Location Not Found",
                        };
                    }
                }
                throw;
            }
        }
    }
}
