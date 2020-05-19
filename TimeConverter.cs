using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeConverterNS
{
    class TimeConverter
    {
        public static DateTime? ConvertToEastern(string user_input_time, string user_input_zone)
        {

            DateTime user_time;
            DateTime.TryParse(user_input_time, out user_time);
            TimeZoneInfo user_timezone = TimeZoneInfo.FindSystemTimeZoneById(user_input_zone);
            TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            if (user_time.Equals(DateTime.MinValue))
            {
                Console.WriteLine("This is an invalid time");
                return null;
            }

            else
            {
                DateTime estTime = TimeZoneInfo.ConvertTime(user_time, user_timezone, est);
                return estTime;
            }

        }

        public static bool IsTodayInList(string user_days)
        {
            List<string> list_of_days_string = user_days.Split(',').ToList();
            List<int> list_of_days = list_of_days_string.Select(int.Parse).ToList();
            DayOfWeek today = DateTime.Now.DayOfWeek;
            var num = (int)today;

            return list_of_days.Contains(num);
        }
    }
}

