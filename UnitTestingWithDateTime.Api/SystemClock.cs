using System;

namespace UnitTestingWithDateTime.Api
{
    public class SystemClock : ISystemClock
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}