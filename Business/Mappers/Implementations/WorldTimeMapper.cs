using Business.DTO;
using Business.DTO.WorldTime;
using Business.Mappers.Abstractions;
using Business.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers.Implementations
{
    public class WorldTimeMapper : IWorldTimeMapper
    {
        public TimeDTO Map(WorldTimeDTO mapEntity)
        {
            long unixTime = DateTimeUtils.GetUnixTimeFromDateTime(mapEntity.datetime);

            TimeDTO timeDTO = new TimeDTO();
            timeDTO.Time = DateTimeUtils.GetDateTimeFromUnixSeconds(unixTime);

            return timeDTO;
        }
    }
}
