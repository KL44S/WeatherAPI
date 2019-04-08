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
        protected override long GetMaxUnitTime(long sunriseUnixTime, long sunsetUnixTime)
        {
            return sunsetUnixTime;
        }

        public DuskService() : base(DayTime.Dusk) { }

        public DuskService(IDayTimeService nextDayTimeService) : base(DayTime.Dusk, nextDayTimeService) { }
    }
}