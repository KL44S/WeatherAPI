using Business.DTO;
using Business.DTO.OpenWeather;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers.Abstractions
{
    public interface IOpenWeatherMapper : ISingleEntityMapper<WeatherDTO, OpenWeatherDTO>
    {
    }
}
