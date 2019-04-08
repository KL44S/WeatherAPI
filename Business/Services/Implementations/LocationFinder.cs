using System.Threading.Tasks;
using Model;
using Business.DTO.KeyCDNGeoIpLocation;
using Business.Services.Abstractions;
using Business.Mappers.Implementations;
using Business.DTO;

namespace Business.Services.Implementations
{
    public class LocationFinder : ILocationFinder
    {
        private static string _ipLocationApiUrl = @"https://tools.keycdn.com/geo.json?host=";

        private IGenericRestService _genericRestService;
        private KeyCDNGeoIpLocationMapper _locationMapper;

        public LocationFinder(IGenericRestService genericRestService, KeyCDNGeoIpLocationMapper locationMapper)
        {
            this._genericRestService = genericRestService;
            this._locationMapper = locationMapper;
        }

        public async Task<LocationDTO> FindLocationByIp(string ip)
        {
            string fullUrl = _ipLocationApiUrl + ip;

            GeoIpLocationDTO locationDTO = await this._genericRestService.Get<GeoIpLocationDTO>(fullUrl);

            LocationDTO location = this._locationMapper.Map(locationDTO);

            return location;
        }
    }
}
