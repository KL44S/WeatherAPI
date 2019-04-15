using Business.DTO;
using Business.DTO.OpenWeather;
using Business.Exceptions;
using Business.Mappers.Abstractions;
using Business.Services.Abstractions;
using Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class WeatherStateService : IWeatherStateService
    {
        private static string _appToken = @"df104e81c71f0c76df172d6015064b15";
        private static string _openWeatherApiUrl = @"https://api.openweathermap.org/data/2.5/weather?appid=" + _appToken
                                            + @"&units=metric&q=";
        private static string _citySeparator = ",";

        private IGenericRestService _genericRestService;
        private IOpenWeatherMapper _weatherMapper;

        public WeatherStateService(IGenericRestService genericRestService, IOpenWeatherMapper weatherMapper)
        {
            this._genericRestService = genericRestService;
            this._weatherMapper = weatherMapper;
        }

        public async Task<WeatherDTO> GetWeatherStateFromLocation(LocationDTO locationDTO)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(_openWeatherApiUrl);
                stringBuilder.Append(locationDTO.CityName);
                stringBuilder.Append(_citySeparator);
                stringBuilder.Append(locationDTO.CountryCode);

                string fullUrl = stringBuilder.ToString();

                OpenWeatherDTO openWeatherDTO = await this._genericRestService.Get<OpenWeatherDTO>(fullUrl);
                WeatherDTO weatherDTO = this._weatherMapper.Map(openWeatherDTO);

                return weatherDTO;
            }
            catch (NotFoundException)
            {
                throw new NoWeatherStateFoundException();
            }

        }
    }
}
