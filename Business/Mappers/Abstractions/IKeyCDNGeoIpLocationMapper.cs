using Business.DTO;
using Business.DTO.KeyCDNGeoIpLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers.Abstractions
{
    public interface IKeyCDNGeoIpLocationMapper : ISingleEntityMapper<LocationDTO, GeoIpLocationDTO>
    {
    }
}
