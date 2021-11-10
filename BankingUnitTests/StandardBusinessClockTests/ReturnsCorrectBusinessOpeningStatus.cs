using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingUnitTests.StandardBusinessClockTests
{
    public class ReturnsCorrectBusinessOpeningStatus
    {
        [Fact]
        public void Between9And5IsOpen()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(c => c.GetCurrent())
                .Returns(new DateTime(1969, 4, 20, 11, 39, 00));
            IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);


            Assert.True(clock.IsDuringBusinessHours());
        }

        [Fact]
        public void OtherwiseClosed()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(c => c.GetCurrent())
                 .Returns(new DateTime(1969, 4, 20, 18, 39, 00));
            IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);
      

            Assert.False(clock.IsDuringBusinessHours());
        }
    }
}
