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
            DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
            long unixTime = dateTimeOffset.ToUnixTimeSeconds();

            return unixTime;
        }
    }
}
