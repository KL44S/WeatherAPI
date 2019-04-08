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
        protected override long GetMaxUnitTime(long sunriseUnixTime, long sunsetUnixTime)
        {
            return sunriseUnixTime;
        }

        public NoonService() : base(DayTime.Noon) { }

        public NoonService(IDayTimeService nextDayTimeService) : base(DayTime.Noon, nextDayTimeService) { }
    }
}
