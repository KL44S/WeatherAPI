using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstractions
{
    public interface IDayTimeService
    {
        DayTime GetDayTime(DateTime sunriseTime, DateTime sunsetTime, DateTime currentTime);
    }
}
