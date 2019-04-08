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
        protected override long GetMaxUnitTime(long sunriseUnixTime, long sunsetUnixTime)
        {
            DateTime sunrise = DateTimeUtils.GetDateTimeFromUnixSeconds(sunriseUnixTime);
            DateTime sunset = DateTimeUtils.GetDateTimeFromUnixSeconds(sunsetUnixTime);

            int noonHour =( ((sunset.Hour - sunrise.Hour) / 2) + sunrise.Hour);

            DateTime anHourAgoOfNoon = new DateTime(noonHour - 1, sunrise.Month, sunrise.Day);

            long maxUnixTime = DateTimeUtils.GetUnixTimeFromDateTime(anHourAgoOfNoon);

            return maxUnixTime;
        }

        public MorningService() : base(DayTime.Morning) { }

        public MorningService(IDayTimeService nextDayTimeService) : base(DayTime.Morning, nextDayTimeService) { }
    }
}
