using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Business.Services.Abstractions
{
    public abstract class DayTimeService : IDayTimeService
    {
        private static long _invalidMinUnixTime = -1;
        protected static long _minUnixTime = _invalidMinUnixTime;

        protected DayTime _dayTime;
        private IDayTimeService _nextDayTimeService;
        
        protected abstract long GetMaxUnitTime(long sunriseUnixTime, long sunsetUnixTime);

        protected DayTimeService(DayTime dayTime)
        {
            this._dayTime = dayTime;
        }

        protected DayTimeService(DayTime dayTime, IDayTimeService nextDayTimeService)
        {
            this._dayTime = dayTime;
            this._nextDayTimeService = nextDayTimeService;
        }

        private void InitMinUnixTimeIfItIsNecessary(long sunriseUnixTime)
        {
            if (_minUnixTime.Equals(_invalidMinUnixTime))
            {
                _minUnixTime = sunriseUnixTime;
            }
        }

        public DayTime GetDayTime(long sunriseUnixTime, long sunsetUnixTime, long currentUnixTime)
        {
            this.InitMinUnixTimeIfItIsNecessary(sunriseUnixTime);

            DayTime resultDayTime = this._dayTime;

            long maxUnixTime = this.GetMaxUnitTime(sunriseUnixTime, sunsetUnixTime);

            Boolean isMyDayTimePeriod = (currentUnixTime > _minUnixTime && currentUnixTime <= maxUnixTime);

            if (!isMyDayTimePeriod && this._nextDayTimeService != null)
            {
                _minUnixTime = maxUnixTime;
                resultDayTime = this._nextDayTimeService.GetDayTime(sunriseUnixTime, sunsetUnixTime, currentUnixTime);
            }

            return resultDayTime;
        }
    }
}
