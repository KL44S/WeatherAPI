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

        private Weather GetWeather(WeatherDTO weatherDTO, long currentUnixTime)
        {
            Weather weather = new Weather();
            weather.WeatherState = weatherDTO.WeatherState;
            weather.DayTime = this._dayTimeService.GetDayTime(weatherDTO.SunriseUnixTime, weatherDTO.SunsetUnixTime, currentUnixTime);

            return weather;
        }

        public WeatherService(IWeatherStateService weatherStateService,
                                ILocationFinder locationFinder,
                                IDayTimeServiceFactory dayTimeServiceFactory)
        {
            this._weatherStateService = weatherStateService;
            this._locationFinder = locationFinder;
            this._dayTimeService = dayTimeServiceFactory.BuildAndGetInstance();
        }

        public Weather GetWeatherFromIp(string ip)
        {
            LocationDTO locationDTO = this.GetLocationDTO(ip);
            WeatherDTO weatherDTO = this.GetWeatherDTO(locationDTO);

            Weather weather = this.GetWeather(weatherDTO, locationDTO.UnixTime);

            return weather;
        }
    }
}
