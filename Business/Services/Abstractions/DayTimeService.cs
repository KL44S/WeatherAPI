using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Business.Services.Abstractions
{
    public abstract class DayTimeService : IDayTimeService
    {
        protected static DateTime? _minTime;

        protected DayTime _dayTime;
        private IDayTimeService _nextDayTimeService;
        
        protected abstract DateTime GetMaxUnitTime(DateTime sunriseTime, DateTime sunsetTime);

        protected DayTimeService(DayTime dayTime)
        {
            this._dayTime = dayTime;
        }

        protected DayTimeService(DayTime dayTime, IDayTimeService nextDayTimeService)
        {
            this._dayTime = dayTime;
            this._nextDayTimeService = nextDayTimeService;
        }

        private void InitMinUnixTimeIfItIsNecessary(DateTime sunriseTime)
        {
            if (!_minTime.HasValue)
            {
                _minTime = sunriseTime;
            }
        }

        public DayTime GetDayTime(DateTime sunriseTime, DateTime sunsetTime, DateTime currentTime)
        {
            this.InitMinUnixTimeIfItIsNecessary(sunriseTime);

            DayTime resultDayTime = this._dayTime;

            DateTime maxTime = this.GetMaxUnitTime(sunriseTime, sunsetTime);

            int minTimeComparisonResult = currentTime.CompareTo(_minTime);
            int maxTimeComparisonResult = currentTime.CompareTo(maxTime);

            Boolean isMyDayTimePeriod = (minTimeComparisonResult > 0 && maxTimeComparisonResult <= 0);

            if (!isMyDayTimePeriod && this._nextDayTimeService != null)
            {
                _minTime = maxTime;
                resultDayTime = this._nextDayTimeService.GetDayTime(sunriseTime, sunsetTime, currentTime);
            }

            return resultDayTime;
        }
    }
}
