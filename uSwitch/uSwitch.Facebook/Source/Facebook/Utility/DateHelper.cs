using System;

namespace Facebook.Utility {
    internal sealed class DateHelper {
        private DateHelper() {
        }

        /// <summary>
        /// Convert UTC time, as returned by Facebook, to localtime.
        /// </summary>
        /// <param name="secondsSinceEpoch">The number of seconds since Jan 1, 1970.</param>
        /// <returns>Local time.</returns>
        internal static DateTime ConvertDoubleToDate(double secondsSinceEpoch) {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            DateTime utcdate = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(secondsSinceEpoch);
            DateTime localTime = localZone.ToLocalTime(utcdate);

            return localTime;
        }

        /// <summary>
        /// Convert datetime to UTC time, as understood by Facebook.
        /// </summary>
        /// <param name="dateToConvert">The date that we need to pass to the api.</param>
        /// <returns>The number of seconds since Jan 1, 1970.</returns>
        internal static double ConvertDateToDouble(DateTime dateToConvert) {
            double result;
            DateTime utcDate = new DateTime(1970, 1, 1, 0, 0, 0);
            TimeSpan span = dateToConvert - utcDate;
            result = span.Seconds;
            return result;
        }
    }
}