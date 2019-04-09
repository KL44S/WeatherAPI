using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utils
{
    public class DateTimeUtils
    {
        public static DateTime GetDateTimeFromUnixSeconds(long unixSeconds)
        {
            DateTime datetime = DateTimeOffset.FromUnixTimeSeconds(unixSeconds).DateTime;

            return datetime;
        }

        public static long GetUnixTimeFromDateTime(DateTime dateTime)
        {
            //long unixTime = (long)dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime.ToUniversalTime());
            long unixTime = dateTimeOffset.ToUniversalTime().ToUnixTimeSeconds();

            return unixTime;
        }

        public static DateTime GetNoon(DateTime sunriseTime, DateTime sunsetTime)
        {
            TimeSpan noonHour = new TimeSpan((sunsetTime.TimeOfDay - sunriseTime.TimeOfDay).Ticks / 2);
            DateTime noon = (sunriseTime + noonHour);

            return noon;
        }
    }
}
