using Business.Abstractions;
using Business.DTO;
using Business.DTO.OpenWeather;
using Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class WeatherStateService : IWeatherStateService
    {
        private static string _appToken = @"df104e81c71f0c76df172d6015064b15";
        private static string _openWeatherApiUrl = @"https://api.openweathermap.org/data/2.5/weather?appid=" + _appToken
                                            + @"&units=metric&q=";
        private static string _citySeparator = ",";

        private IGenericRestService _genericRestService;

        public WeatherStateService(IGenericRestService genericRestService)
        {
            this._genericRestService = genericRestService;
        }

        public async Task<WeatherDTO> GetWeatherStateFromLocation(Location location)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(_openWeatherApiUrl);
            stringBuilder.Append(location.CityName);
            stringBuilder.Append(_citySeparator);
            stringBuilder.Append(location.CountryCode);

            string fullUrl = stringBuilder.ToString();

            OpenWeatherDTO openWeatherDTO =  await this._genericRestService.Get<OpenWeatherDTO>(fullUrl);
            WeatherDTO weatherDTO = (WeatherDTO)openWeatherDTO;

            return weatherDTO;
        }
    }
}
