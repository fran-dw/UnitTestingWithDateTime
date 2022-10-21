using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UnitTestingWithDateTime.Api;

namespace UnitTestingWithDateTime.Tests.Unit
{
    [TestFixture]
    public class DayPartServiceTests
    {
        private readonly Mock<ISystemClock> _systemClockMock;
        private readonly DayPartService _sut;

        public DayPartServiceTests()
        {
            _systemClockMock = new Mock<ISystemClock>();
            _sut = new DayPartService(_systemClockMock.Object);
        }

        [TestCase(6, TestName = "Time is 6am")]
        [TestCase(7, TestName = "Time is 7am")]
        [TestCase(8, TestName = "Time is 8am")]
        [TestCase(9, TestName = "Time is 9am")]
        [TestCase(10, TestName = "Time is 10am")]
        [TestCase(11, TestName = "Time is 11am")]
        public void GetCurrentDayPart_ShouldReturnMorning_WhenItIsMorning(int hour)
        {
            // Arrange
            const string expectedGreeting = "Morning";
            var dateTime = new DateTime(2022, 1, 1, hour, 0, 0);
            _systemClockMock.Setup(x => x.UtcNow).Returns(dateTime);

            // Act
            var greeting = _sut.GetCurrentDayPart();

            // Assert
            greeting.Should().Be(expectedGreeting);
        }

        [TestCase(12, TestName = "Time is 12pm")]
        [TestCase(13, TestName = "Time is 1pm")]
        [TestCase(14, TestName = "Time is 2pm")]
        [TestCase(15, TestName = "Time is 3pm")]
        [TestCase(16, TestName = "Time is 4pm")]
        [TestCase(17, TestName = "Time is 5pm")]
        public void GetCurrentDayPart_ShouldReturnAfternoon_WhenItIsAfternoon(int hour)
        {
            // Arrange
            const string expectedGreeting = "Afternoon";
            var dateTime = new DateTime(2022, 1, 1, hour, 0, 0);
            _systemClockMock.Setup(x => x.UtcNow).Returns(dateTime);

            // Act
            var greeting = _sut.GetCurrentDayPart();

            // Assert
            greeting.Should().Be(expectedGreeting);
        }

        [TestCase(18, TestName = "Time is 6pm")]
        [TestCase(19, TestName = "Time is 7pm")]
        [TestCase(20, TestName = "Time is 8pm")]
        [TestCase(21, TestName = "Time is 9pm")]
        [TestCase(22, TestName = "Time is 10pm")]
        [TestCase(23, TestName = "Time is 11pm")]
        public void GetCurrentDayPart_ShouldReturnEvening_WhenItIsEvening(int hour)
        {
            // Arrange
            const string expectedGreeting = "Evening";
            var dateTime = new DateTime(2022, 1, 1, hour, 0, 0);
            _systemClockMock.Setup(x => x.UtcNow).Returns(dateTime);

            // Act
            var greeting = _sut.GetCurrentDayPart();

            // Assert
            greeting.Should().Be(expectedGreeting);
        }

        [TestCase(0, TestName = "Time is 12am")]
        [TestCase(1, TestName = "Time is 1am")]
        [TestCase(2, TestName = "Time is 2am")]
        [TestCase(3, TestName = "Time is 3am")]
        [TestCase(4, TestName = "Time is 4am")]
        [TestCase(5, TestName = "Time is 5am")]
        public void GetCurrentDayPart_ShouldReturnNight_WhenItIsNight(int hour)
        {
            // Arrange
            const string expectedGreeting = "Night";
            var dateTime = new DateTime(2022, 1, 1, hour, 0, 0);
            _systemClockMock.Setup(x => x.UtcNow).Returns(dateTime);

            // Act
            var greeting = _sut.GetCurrentDayPart();

            // Assert
            greeting.Should().Be(expectedGreeting);
        }
    }
}