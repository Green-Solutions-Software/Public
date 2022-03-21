using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.OmniChannelSystem.Rest.SDK.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime TimezoneToUTC(this DateTime dt, string timeZone = "W. Europe Standard Time")
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeToUtc(dt, timeZoneInfo);
        }

        public static DateTime TimezoneFromUTC(this DateTime dt, string timeZone = "W. Europe Standard Time")
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeFromUtc(dt, timeZoneInfo);
        }

        public static DateTime ToTimeZone(this DateTime dt, string timeZone = "W. Europe Standard Time")
        {
            if (dt.Kind == DateTimeKind.Unspecified)
            {
                var servertTime = DateTime.SpecifyKind(dt, DateTimeKind.Utc);

                return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(servertTime, TimeZoneInfo.Utc.Id, timeZone);
            }
            if (dt.Kind == DateTimeKind.Local)
            {
                var servertTime = dt.ToUniversalTime();

                return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(servertTime, TimeZoneInfo.Utc.Id, timeZone);
            }

            if (dt.Kind == DateTimeKind.Utc)
            {
                return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dt, TimeZoneInfo.Utc.Id, timeZone);
            }

            return dt;
        }
    }
}
