using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DTO.OpenWeather
{
    internal class OpenWeatherConstants
    {
        public IDictionary<int, WeatherState> WeatherStateById = new Dictionary<int, WeatherState>()
        {
            { 200, WeatherState.Rain },
            { 201, WeatherState.Rain },
            { 202, WeatherState.Rain },
            { 200, WeatherState.Rain },
            { 200, WeatherState.Rain },
            { 200, WeatherState.Rain },
            { 200, WeatherState.Rain },
            { 200, WeatherState.Rain },
            { 200, WeatherState.Rain },
            { 200, WeatherState.Rain },
            { 200, WeatherState.Rain },
            { 200, WeatherState.Rain },
            { 200, WeatherState.Rain },
        };
    }
}
