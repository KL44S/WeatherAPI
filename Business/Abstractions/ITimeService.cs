using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions
{
    public interface ITimeService
    {
        Task<int> GetUnixTimeFromIp(string ip);
    }
}
