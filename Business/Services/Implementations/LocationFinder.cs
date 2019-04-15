using System.Threading.Tasks;
using Model;
using Business.DTO.KeyCDNGeoIpLocation;
using Business.Services.Abstractions;
using Business.DTO;
using Business.Mappers.Abstractions;
using System;
using Business.Exceptions;

namespace Business.Services.Implementations
{
    public class LocationFinder : ILocationFinder
    {
        private static string _ipLocationApiUrl = @"https://tools.keycdn.com/geo.json?host=";

        private IGenericRestService _genericRestService;
        private IKeyCDNGeoIpLocationMapper _locationMapper;

        private bool IsValid(GeoIpLocationDTO geoIpLocationDTO)
        {
            bool isValid = (geoIpLocationDTO != null && !string.IsNullOrEmpty(geoIpLocationDTO.data.geo.city));

            return isValid;
        }

        public LocationFinder(IGenericRestService genericRestService, IKeyCDNGeoIpLocationMapper locationMapper)
        {
            this._genericRestService = genericRestService;
            this._locationMapper = locationMapper;
        }

        public async Task<LocationDTO> FindLocationByIp(string ip)
        {
            try
            {
                string fullUrl = _ipLocationApiUrl + ip;

                GeoIpLocationDTO geoIpLocationDTO = await this._genericRestService.Get<GeoIpLocationDTO>(fullUrl);

                if (!this.IsValid(geoIpLocationDTO))
                {
                    throw new NoLocationFoundException();
                }

                LocationDTO locationDTO = this._locationMapper.Map(geoIpLocationDTO);

                return locationDTO;
            }
            catch (NotFoundException)
            {
                throw new NoLocationFoundException();
            }
        }
    }
}
