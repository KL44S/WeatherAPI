using Business.DTO;
using Business.DTO.WorldTime;
using Business.Exceptions;
using Business.Mappers.Abstractions;
using Business.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class TimeService : ITimeService
    {
        private static string _worldTimeAPIUrl = @"http://worldtimeapi.org/api/ip/";

        private IGenericRestService _genericRestService;
        private IWorldTimeMapper _worldTimeMapper;

        private bool IsValid(WorldTimeDTO worldTimeDTO)
        {
            bool isValid = (worldTimeDTO != null);

            return isValid;
        }

        public TimeService(IGenericRestService genericRestService, IWorldTimeMapper worldTimeMapper)
        {
            this._genericRestService = genericRestService;
            this._worldTimeMapper = worldTimeMapper;
        }

        public async Task<TimeDTO> GetTimeFromIp(string ip)
        {
            try
            {
                string fullUrl = _worldTimeAPIUrl + ip;

                WorldTimeDTO worldTimeDTO = await this._genericRestService.Get<WorldTimeDTO>(fullUrl);

                if (!this.IsValid(worldTimeDTO))
                {
                    throw new NoTimeFoundException();
                }

                TimeDTO timeDTO = this._worldTimeMapper.Map(worldTimeDTO);

                return timeDTO;
            }
            catch (NotFoundException)
            {
                throw new NoTimeFoundException();
            }
        }
    }
}
