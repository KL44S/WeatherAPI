using Business.Services.Abstractions;
using Business.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Implementations.DayTimes
{
    public class NoonService : DayTimeService
    {
        protected override DateTime GetMaxUnitTime(DateTime sunriseTime, DateTime sunsetTime)
        {
            DateTime noon = DateTimeUtils.GetNoon(sunriseTime, sunsetTime);
            DateTime anHourAfterOfNoon = noon.AddHours(1);

            return anHourAfterOfNoon;
        }

        public NoonService() : base(DayTime.Noon) { }

        public NoonService(IDayTimeService nextDayTimeService) : base(DayTime.Noon, nextDayTimeService) { }
    }
}
