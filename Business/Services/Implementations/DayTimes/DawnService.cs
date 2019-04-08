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
        protected override long GetMaxUnitTime(long sunriseUnixTime, long sunsetUnixTime)
        {
            DateTime sunriseTime = DateTimeUtils.GetDateTimeFromUnixSeconds(sunriseUnixTime);
            DateTime anHourLaterFromSunrise = sunriseTime.AddHours(1);

            long maxUnixTime = DateTimeUtils.GetUnixTimeFromDateTime(anHourLaterFromSunrise);

            return maxUnixTime;
        }

        public DawnService() : base(DayTime.Dawn) { }

        public DawnService(IDayTimeService nextDayTimeService) : base(DayTime.Dawn, nextDayTimeService) { }
    }
}
