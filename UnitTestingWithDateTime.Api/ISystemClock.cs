using System;

namespace UnitTestingWithDateTime.Api
{
    public interface ISystemClock
    {
        DateTime UtcNow { get; }
    }
}