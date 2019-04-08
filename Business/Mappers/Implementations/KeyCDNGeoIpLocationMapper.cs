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
    public class KeyCDNGeoIpLocationMapper : ISingleEntityMapper<LocationDTO, GeoIpLocationDTO>
    {
        public LocationDTO Map(GeoIpLocationDTO geoIpLocationDTO)
        {
            LocationDTO location = new LocationDTO();
            location.CityName = geoIpLocationDTO.data.geo.city;
            location.CountryCode = geoIpLocationDTO.data.geo.country_code;
            location.UnixTime = DateTimeUtils.GetUnixTimeFromDateTime(geoIpLocationDTO.data.geo.datetime);

            return location;
        }
    }
}
