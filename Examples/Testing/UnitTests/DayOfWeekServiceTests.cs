using System;
using FluentAssertions;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayOfWeekServiceTests
    {
        private DayOfWeekService ServiceInstance = new DayOfWeekService();

        [Test]
        public void IsWeekend_RealLogic_Friday_Returns_False()
        {
            var today = new DateTime(2020, 10, 02); // Friday

            var result = this.ServiceInstance.IsWeekend(today);

            result.Should().Be(false);
        }

        [Test]
        public void IsWeekend_RealLogic_Sunday_Returns_True()
        {
            var today = new DateTime(2020, 10, 04); // Sunday

            var result = this.ServiceInstance.IsWeekend(today);

            result.Should().Be(true);
        }

        [Test]
        public void IsWeekend_RealLogin_Weekend_Different_Year_Returns_True()
        {
            var today = new DateTime(2019, 10, 08); // Sunday

            var result = this.ServiceInstance.IsWeekend(today);

            result.Should().Be(true);
        }

        [Test]
        public void IsWeekend_RealLogin_Weekend_Different_Year_Returns_False()
        {
            var today = new DateTime(2019, 10, 09); // Monday

            var result = this.ServiceInstance.IsWeekend(today);

            result.Should().Be(false);
        }
    }
}