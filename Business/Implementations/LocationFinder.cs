using Business.Abstractions;
using System.Threading.Tasks;
using Model;
using Business.DTO.KeyCDNGeoIpLocation;

namespace Business.Implementations
{
    public class LocationFinder : ILocationFinder
    {
        private static string _ipLocationApiUrl = @"https://tools.keycdn.com/geo.json?host=";

        private IGenericRestService _genericRestService;

        public LocationFinder(IGenericRestService genericRestService)
        {
            this._genericRestService = genericRestService;
        }

        public async Task<Location> FindLocationByIp(string ip)
        {
            string fullUrl = _ipLocationApiUrl + ip;

            GeoIpLocationDTO locationDTO = await this._genericRestService.Get<GeoIpLocationDTO>(fullUrl);

            Location location = (Location)locationDTO;

            return location;
        }
    }
}
