using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using Model;

namespace Business.Services.Abstractions
{
    public interface ILocationFinder
    {
        Task<LocationDTO> FindLocationByIp(string ip);
    }
}
