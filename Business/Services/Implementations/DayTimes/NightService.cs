using Business.Services.Abstractions;
using Business.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Implementations.DayTimes
{
    public class NightService : DayTimeService
    {
        protected override DateTime GetMaxUnitTime(DateTime sunriseTime, DateTime sunsetTime)
        {
            return sunriseTime;
        }

        public NightService() : base(DayTime.Night) { }

        public NightService(IDayTimeService nextDayTimeService) : base(DayTime.Night, nextDayTimeService) { }
    }
}
