using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DTO
{
    public class WeatherDTO
    {
        public WeatherState WeatherState { get; set; }
        public DateTime SunriseTime { get; set; }
        public DateTime SunsetTime { get; set; }
    }
}
