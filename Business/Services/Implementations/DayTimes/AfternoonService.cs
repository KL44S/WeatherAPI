using Business.Services.Abstractions;
using Business.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Implementations.DayTimes
{
    public class AfternoonService : DayTimeService
    {
        protected override DateTime GetMaxUnitTime(DateTime sunriseTime, DateTime sunsetTime)
        {
            DateTime anHourAgoOfSunset = sunsetTime.AddHours(-1);

            return anHourAgoOfSunset;
        }

        public AfternoonService() : base(DayTime.Afternoon) { }

        public AfternoonService(IDayTimeService nextDayTimeService) : base(DayTime.Afternoon, nextDayTimeService) { }
    }
}
