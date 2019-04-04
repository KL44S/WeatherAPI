using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions
{
    public interface IWeatherService
    {
        Weather GetWeatherFromIp(string ip);
    }
}
