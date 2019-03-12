using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Maintain.NET.Models;

namespace MaintainNETTestSuite.ModelTests
{
    public class TimeConverterTests
    {
        [Fact]
        public void UnixtoDateWorks()
        {
            //arrange
            TimeConverter timeConverter = new TimeConverter();
            long unixDate = 1552413968;
            DateTime expectedDate = new DateTime(2019, 3, 12, 11, 6, 8);

            //Act
            DateTime date = timeConverter.UnixToDate(unixDate);

            //Assert
            Assert.Equal(expectedDate, date);
        }

        [Fact]
        public void DateToUnixWorks()
        {
            //arrange
            TimeConverter timeConverter = new TimeConverter();
            DateTime date = new DateTime(2019, 3, 12, 11, 6, 8);

            //Act
            long unixDate = timeConverter.DateToUnix(date);

            //Assert
            Assert.Equal(1552413968, unixDate);
        }


        [Fact]
        public void CalculateIntervalWorks()
        {
            //arrange
            TimeConverter timeConverter = new TimeConverter();
            long unixDate = 1552413968;

            //Act
            long result = timeConverter.CalculateInterval(unixDate);

            //Assert
            Assert.IsType<long>(result);
        }

        [Fact]
        public void CalculateTaskAlertWorks()
        {
            //arrange
            TimeConverter timeConverter = new TimeConverter();
            long response = 3061;

            //Act
            long result = timeConverter.CalculateTaskAlert(response);

            //Assert
            Assert.IsType<long>(result);
        }


    }
}
