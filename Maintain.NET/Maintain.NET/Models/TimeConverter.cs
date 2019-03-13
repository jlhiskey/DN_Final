using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Models
{
    public class TimeConverter
    {
        /// <summary>
        /// Converts Unix Time to date time
        /// </summary>
        /// <param name="stamp">Unix date stamp</param>
        /// <returns>Date Time</returns>
        public DateTime UnixToDate(long stamp)
        {
            DateTime resultDate = new DateTime(1970, 1, 1).AddSeconds(stamp).ToLocalTime();

            return resultDate;
        }

        /// <summary>
        /// Converts date time to unix time
        /// </summary>
        /// <param name="date">Date</param>
        /// <returns>long unix date</returns>
        public long DateToUnix(DateTime date)
        {

            long resultUix = ((DateTimeOffset)date).ToUnixTimeSeconds();

            return resultUix;
        }

        /// <summary>
        /// Gets last task complete unix time and calculates the interval between last complete and current complete
        /// </summary>
        /// <param name="lastComplete">Unix time</param>
        /// <returns>interval in miliseconds</returns>
        public long CalculateInterval(long lastComplete)
        {
            DateTime now = DateTime.UtcNow;

            long newComplete = ((DateTimeOffset)now).ToUnixTimeSeconds();

            long interval = newComplete - lastComplete;

            return interval;
        }

        /// <summary>
        /// takes in response from machine learning and calculates a new task due date
        /// </summary>
        /// <param name="machineLearningResponse">long respons</param>
        /// <returns>Unix date task due date</returns>
        public long CalculateTaskAlert(long machineLearningResponse)
        {
            DateTime now = DateTime.UtcNow;

            long currentDate = ((DateTimeOffset)now).ToUnixTimeSeconds();

            long taskDueDate = currentDate + machineLearningResponse;

            return taskDueDate;
        }
    }
}
