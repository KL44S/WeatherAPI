using Business.DTO;
using Business.DTO.KeyCDNGeoIpLocation;
using Business.Mappers.Abstractions;
using Business.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers.Implementations
{
    public class KeyCDNGeoIpLocationMapper : IKeyCDNGeoIpLocationMapper
    {
        public LocationDTO Map(GeoIpLocationDTO geoIpLocationDTO)
        {
            LocationDTO location = new LocationDTO();
            location.CityName = geoIpLocationDTO.data.geo.city;
            location.CountryCode = geoIpLocationDTO.data.geo.country_code;

            return location;
        }
    }
}
