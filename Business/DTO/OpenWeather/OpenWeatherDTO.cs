using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.DTO.OpenWeather
{
    public class OpenWeatherDTO
    {
        public SysDTO sys { get; set; }
        public IList<WeatherSateDTO> weather { get; set; }
    }
}
