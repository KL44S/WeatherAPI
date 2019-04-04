using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Business.Abstractions
{
    public interface ILocationFinder
    {
        Task<Location> FindLocationByIp(string ip);
    }
}
