using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private IHttpContextAccessor _accessor;
        private IWeatherService _weatherService;

        public WeatherController(IHttpContextAccessor accessor, IWeatherService weatherService)
        {
            this._accessor = accessor;
            this._weatherService = weatherService;
        }

        [HttpGet]
        public ActionResult<Weather> Get(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                ip = this._accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }

            Weather weather = this._weatherService.GetWeatherFromIp(ip);

            return weather;
        }

    }
}
