using Business.Services.Abstractions;
using Business.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Implementations.DayTimes
{
    public class DawnService : DayTimeService
    {
        protected override DateTime GetMaxUnitTime(DateTime sunriseTime, DateTime sunsetTime)
        {
            DateTime anHourLaterFromSunrise = sunriseTime.AddHours(1);

            return anHourLaterFromSunrise;
        }

        public DawnService() : base(DayTime.Dawn) { }

        public DawnService(IDayTimeService nextDayTimeService) : base(DayTime.Dawn, nextDayTimeService) { }
    }
}
