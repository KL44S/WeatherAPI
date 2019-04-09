using Business.DTO;
using Business.Factories.Absctractions;
using Business.Services.Abstractions;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class WeatherService : IWeatherService
    {
        private IWeatherStateService _weatherStateService;
        private ILocationFinder _locationFinder;
        private IDayTimeService _dayTimeService;
        private ITimeService _timeService;

        private WeatherDTO GetWeatherDTO(LocationDTO locationDTO)
        {
            Task<WeatherDTO> weatherDtoTask = this._weatherStateService.GetWeatherStateFromLocation(locationDTO);
            weatherDtoTask.Wait();

            return weatherDtoTask.Result;
        }

        private LocationDTO GetLocationDTO(string ip)
        {
            Task<LocationDTO> locationTask = this._locationFinder.FindLocationByIp(ip);
            locationTask.Wait();

            return locationTask.Result;
        }

        private Weather GetWeather(WeatherDTO weatherDTO, TimeDTO timeDTO)
        {
            Weather weather = new Weather();
            weather.WeatherState = weatherDTO.WeatherState;
            weather.DayTime = this._dayTimeService.GetDayTime(weatherDTO.SunriseTime, weatherDTO.SunsetTime, timeDTO.Time);

            return weather;
        }

        public WeatherService(IWeatherStateService weatherStateService,
                                ILocationFinder locationFinder,
                                IDayTimeServiceFactory dayTimeServiceFactory,
                                ITimeService timeService)
        {
            this._weatherStateService = weatherStateService;
            this._locationFinder = locationFinder;
            this._dayTimeService = dayTimeServiceFactory.BuildAndGetInstance();
            this._timeService = timeService;
        }

        public Weather GetWeatherFromIp(string ip)
        {
            Task<LocationDTO> locationTask = this._locationFinder.FindLocationByIp(ip);
            Task<TimeDTO> timeTask = this._timeService.GetTimeFromIp(ip);
            WeatherDTO weatherDTO = null;

            Task weatherDTOTask = locationTask.ContinueWith((task) =>
            {
                LocationDTO locationDTO = task.Result;

                weatherDTO = this.GetWeatherDTO(locationDTO);
            });

            Task.WaitAll(weatherDTOTask, timeTask);

            Weather weather = this.GetWeather(weatherDTO, timeTask.Result);

            return weather;
        }
    }
}
