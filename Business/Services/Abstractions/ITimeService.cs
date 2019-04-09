using Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface ITimeService
    {
        Task<TimeDTO> GetTimeFromIp(string ip);
    }
}
