using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DTO.KeyCDNGeoIpLocation
{
    public class GeoIpLocationDTO
    {
        public DataDTO data { get; set; }

        public static explicit operator Location(GeoIpLocationDTO geoIpLocationDTO)
        {
            Location location = new Location();
            location.CityName = geoIpLocationDTO.data.geo.city;
            location.CountryCode = geoIpLocationDTO.data.geo.country_code;

            return location;
        }
    }
}
