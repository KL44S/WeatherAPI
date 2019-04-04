using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DTO.OpenWeather
{
    public class OpenWeatherDTO
    {
        public SysDTO sys { get; set; }
        public IList<WeatherSateDTO> weather { get; set; }

        public static explicit operator WeatherDTO(OpenWeatherDTO openWeatherDTO)
        {
            WeatherDTO weatherDTO = new WeatherDTO();
            weatherDTO.SunsetUnixTime = openWeatherDTO.sys.sunset;
            weatherDTO.SunriseUnixTime = openWeatherDTO.sys.sunrise;
            weatherDTO.WeatherState = openWeatherDTO.weather[0].main;

            return weatherDTO;
        }
    }
}
