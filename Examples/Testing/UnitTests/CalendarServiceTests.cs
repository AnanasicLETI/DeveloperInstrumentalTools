using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class CalendarServiceTests
    {
        [Test]
        public void GetWorkingToday_RealLogic_Friday_Returns_Monday()
        {
            var today = new DateTime(2020, 10, 02); // Friday

            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));
            
            var result = service.GetWorkingTomorrow(today);
            
            result.Should().Be(new DateTime(2020, 10, 05)); // Monday
        }

        [Test]
        public void GetWorkingYesterday_RealLogic_Monday_Returns_Friday()
        {
            var today = new DateTime(2020, 10, 09); // Monday

            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));

            var result = service.GetWorkingYesterday(today);

            result.Should().Be(new DateTime(2020, 10, 06)); // Friday
        }


        [Test]
        public void GetWorkingYesterday_RealLogic_Friday_Returns_Thursday()
        {
            var today = new DateTime(2020, 10, 13); // Friday

            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));

            var result = service.GetWorkingYesterday(today); // Thursday

            result.Should().Be(new DateTime(2020, 10, 12));
        }

        [Test]
        public void GetWorkingTomorrow_RealLogic_Monday_Returns_Tuesday()
        {
            var today = new DateTime(2020, 10, 09); // Monday

            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));

            var result = service.GetWorkingTomorrow(today);

            result.Should().Be(new DateTime(2020, 10, 10)); // Tuesday
        }

        [Test]
        public void GetWorkingTomorrow_RealLogic_Friday_Returns_Monday()
        {
            var today = new DateTime(2020, 10, 06); // Friday

            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));

            var result = service.GetWorkingTomorrow(today);

            result.Should().Be(new DateTime(2020, 10, 09)); // Monday
        }

        [Test]
        public void GetWorkingToday_AllDatesWorking_Returns_Tomorrow()
        {
            var today = new DateTime(2020, 10, 02);

            var dayOfWeekService = new Mock<IDayOfWeekService>();
            dayOfWeekService
                .Setup(x => x.IsWeekend(It.IsAny<DateTime>()))
                .Returns(false);

            var service = new CalendarService(new DayShiftService(dayOfWeekService.Object));
            
            var result = service.GetWorkingTomorrow(today);
            
            result.Should().Be(new DateTime(2020, 10, 03));
        }
        
        [Test]
        public void GetWorkingToday_AllDatesWorking_Returns_Friday()
        {
            var today = new DateTime(2020, 10, 09);

            var dayOfWeekService = new Mock<IDayOfWeekService>();
            dayOfWeekService
                .Setup(x => x.IsWeekend(It.IsAny<DateTime>()))
                .Returns(false);

            var service = new CalendarService(new DayShiftService(dayOfWeekService.Object));
            
            var result = service.GetWorkingYesterday(today);
            
            result.Should().Be(new DateTime(2020, 10, 06));
        }
    }
}