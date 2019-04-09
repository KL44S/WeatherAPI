using Business.DTO;
using Business.DTO.WorldTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers.Abstractions
{
    public interface IWorldTimeMapper : ISingleEntityMapper<TimeDTO, WorldTimeDTO>
    {
    }
}
