using Business.Services.Abstractions;
using Business.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Implementations.DayTimes
{
    public class MorningService : DayTimeService
    {
        protected override DateTime GetMaxUnitTime(DateTime sunriseTime, DateTime sunsetTime)
        {
            DateTime noon = DateTimeUtils.GetNoon(sunriseTime, sunsetTime);
            DateTime anHourBeforeNoon = noon.AddHours(-1);

            return anHourBeforeNoon;
        }

        public MorningService() : base(DayTime.Morning) { }

        public MorningService(IDayTimeService nextDayTimeService) : base(DayTime.Morning, nextDayTimeService) { }
    }
}
