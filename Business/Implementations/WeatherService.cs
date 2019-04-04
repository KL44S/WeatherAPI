using Business.Abstractions;
using Business.DTO;
using Business.DTO.UnixTimeDTO;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class WeatherService : IWeatherService
    {
        private IWeatherStateService _weatherStateService;
        private ILocationFinder _locationFinder;
        private ITimeService _timeService;

        private WeatherDTO GetWeatherDTO(Location location)
        {
            Task<WeatherDTO> weatherDtoTask = this._weatherStateService.GetWeatherStateFromLocation(location);
            weatherDtoTask.Wait();

            return weatherDtoTask.Result;
        }

        private WeatherState MapAndGetWeatherState(string weatherState)
        {
            //TOOD: implement!
            return WeatherState.Clear;
        }

        private DayTime MapAndGetDayTime(int sunriseUnixTime, int sunsetUnixTime, int currentUnixTime) 
        {
            //TOOD: implement!
            return DayTime.Afternoon;
        }

        private Weather GetWeather(WeatherDTO weatherDTO, int currentUnixTime)
        {
            Weather weather = new Weather();
            weather.WeatherState = this.MapAndGetWeatherState(weatherDTO.WeatherState);
            weather.DayTime = this.MapAndGetDayTime(weatherDTO.SunriseUnixTime, weatherDTO.SunsetUnixTime, currentUnixTime);

            return weather;
        }

        public WeatherService(IWeatherStateService weatherStateService,
                                ILocationFinder locationFinder,
                                ITimeService timeService)
        {
            this._weatherStateService = weatherStateService;
            this._locationFinder = locationFinder;
            this._timeService = timeService;
        }

        public Weather GetWeatherFromIp(string ip)
        {
            Task<Location> locationTask = this._locationFinder.FindLocationByIp(ip);
            Task<int> unixTimeTask = this._timeService.GetUnixTimeFromIp(ip);
            WeatherDTO weatherDTO = null;

            Task weatherDTOTask = locationTask.ContinueWith((task) =>
            {
                Location location = task.Result;

                weatherDTO = this.GetWeatherDTO(location);
            });

            Task.WaitAll(weatherDTOTask, unixTimeTask);

            Weather weather = this.GetWeather(weatherDTO, unixTimeTask.Result);

            return weather;
        }
    }
}
