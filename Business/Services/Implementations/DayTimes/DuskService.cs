using Business.Services.Abstractions;
using Business.Utils;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Implementations.DayTimes
{
    public class DuskService : DayTimeService
    {
        protected override DateTime GetMaxUnitTime(DateTime sunriseTime, DateTime sunsetTime)
        {
            return sunsetTime;
        }

        public DuskService() : base(DayTime.Dusk) { }

        public DuskService(IDayTimeService nextDayTimeService) : base(DayTime.Dusk, nextDayTimeService) { }
    }
}