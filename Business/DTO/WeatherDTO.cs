using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DTO
{
    public class WeatherDTO
    {
        public string WeatherState { get; set; }
        public int SunriseUnixTime { get; set; }
        public int SunsetUnixTime { get; set; }
    }
}
