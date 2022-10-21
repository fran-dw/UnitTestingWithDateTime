using System;

namespace UnitTestingWithDateTime.Api
{
    public class DayPartService
    {
        private readonly ISystemClock _systemClock;

        public DayPartService(ISystemClock systemClock)
        {
            _systemClock = systemClock;
        }
        
        public string GetCurrentDayPart()
        {
            var hour = _systemClock.UtcNow.Hour;

            return hour switch
            {
                >=6 and < 12 => "Morning",
                >=12 and < 18 => "Afternoon",
                >=18 and < 24 => "Evening",
                _ => "Night"
            };
        }
    }
}