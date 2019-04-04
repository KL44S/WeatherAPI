using Business.Abstractions;
using Business.DTO.UnixTimeDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class TimeService : ITimeService
    {
        private static string _worldTimeAPIUrl = @"http://worldtimeapi.org/api/ip/";

        private IGenericRestService _genericRestService;

        public TimeService(IGenericRestService genericRestService)
        {
            this._genericRestService = genericRestService;
        }

        public async Task<int> GetUnixTimeFromIp(string ip)
        {
            string fullUrl = _worldTimeAPIUrl + ip;

            UnixTimeDTO unixTimeDTO = await this._genericRestService.Get<UnixTimeDTO>(fullUrl);

            return unixTimeDTO.unixtime;
        }
    }
}
