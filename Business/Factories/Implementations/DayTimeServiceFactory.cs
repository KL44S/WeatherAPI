using Business.Factories.Absctractions;
using Business.Services.Abstractions;
using Business.Services.Implementations.DayTimes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Factories.Implementations
{
    public class DayTimeServiceFactory : IDayTimeServiceFactory
    {
        public IDayTimeService BuildAndGetInstance()
        {
            IDayTimeService nightService = new NightService();
            IDayTimeService duskService = new DuskService(nightService);
            IDayTimeService afternoonService = new AfternoonService(duskService);
            IDayTimeService noonService = new NoonService(afternoonService);
            IDayTimeService morningService = new NoonService(noonService);
            IDayTimeService dawnService = new DawnService(morningService);

            return dawnService;
        }
    }
}
