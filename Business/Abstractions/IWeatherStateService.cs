using Business.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions
{
    public interface IWeatherStateService
    {
        Task<WeatherDTO> GetWeatherStateFromLocation(Location location);
    }
}
