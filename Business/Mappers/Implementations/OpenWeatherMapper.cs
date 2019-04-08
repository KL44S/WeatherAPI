using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Business.DTO;
using Business.DTO.OpenWeather;
using Business.Mappers.Abstractions;
using Model;

namespace Business.Mappers.Implementations
{
    public class OpenWeatherMapper : ISingleEntityMapper<WeatherDTO, OpenWeatherDTO>
    {
        private static IDictionary<string, WeatherState> _weatherSatesByStartCode = new Dictionary<string, WeatherState>()
        {
            { "2", WeatherState.Rain },
            { "3", WeatherState.Rain },
            { "5", WeatherState.Rain },
            { "6", WeatherState.Snow },
            { "7", WeatherState.Clear },
            { "800", WeatherState.Clear },
            { "80", WeatherState.Cloudy }
        };

        private WeatherState GetWeatherState(int id)
        {
            string code = id.ToString();
            Boolean wasTheWeatherStateFound = false;
            WeatherState weatherStateFound = WeatherState.Clear;
            int index = 0;

            IList<string> startCodes = _weatherSatesByStartCode.Keys.ToList();

            while (!wasTheWeatherStateFound && index < startCodes.Count)
            {
                string startCode = startCodes.ElementAt(index);
                wasTheWeatherStateFound = (code.StartsWith(startCode));

                if (wasTheWeatherStateFound)
                {
                    weatherStateFound = _weatherSatesByStartCode[startCode];
                }

                index++;
            }

            return weatherStateFound;
        }

        public WeatherDTO Map(OpenWeatherDTO openWeatherDTO)
        {
            WeatherDTO weatherDTO = new WeatherDTO();
            weatherDTO.SunsetUnixTime = openWeatherDTO.sys.sunset;
            weatherDTO.SunriseUnixTime = openWeatherDTO.sys.sunrise;
            weatherDTO.WeatherState = this.GetWeatherState(openWeatherDTO.weather[0].id);

            return weatherDTO;
        }
    }
}
