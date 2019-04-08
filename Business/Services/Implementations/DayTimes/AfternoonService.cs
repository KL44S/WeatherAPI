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
        protected override long GetMaxUnitTime(long sunriseUnixTime, long sunsetUnixTime)
        {
            DateTime sunset = DateTimeUtils.GetDateTimeFromUnixSeconds(sunsetUnixTime);
            DateTime anHourAgoOfSunset = sunset.AddHours(-1);

            long maxUnixTime = DateTimeUtils.GetUnixTimeFromDateTime(anHourAgoOfSunset);

            return maxUnixTime;
        }

        public AfternoonService() : base(DayTime.Afternoon) { }

        public AfternoonService(IDayTimeService nextDayTimeService) : base(DayTime.Afternoon, nextDayTimeService) { }
    }
}
