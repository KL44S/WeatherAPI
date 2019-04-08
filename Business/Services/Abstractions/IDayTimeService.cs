using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstractions
{
    public interface IDayTimeService
    {
        DayTime GetDayTime(long sunriseUnixTime, long sunsetUnixTime, long currentUnixTime);
    }
}
