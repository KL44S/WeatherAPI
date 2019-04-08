using Business.DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface IWeatherStateService
    {
        Task<WeatherDTO> GetWeatherStateFromLocation(LocationDTO locationDTO);
    }
}
