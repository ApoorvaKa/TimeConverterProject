using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeConverterNS
{
    class TimeConverter
    {
        // Accept TimeSpans and return a TimeSpan
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
                Console.WriteLine(estTime);
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


        public static bool IsMessageRespondingToSurvey(DateTime survey_sent_time, DateTime response_time)
        {
            DateTime end_survey_time = survey_sent_time.AddMinutes(30);
            return (response_time >= survey_sent_time && response_time <= end_survey_time);
        }

        public static TimeSpan GenerateRandomTime(TimeSpan starting_time, TimeSpan ending_time)
        {
            var rand = new Random();
            TimeSpan survey_range = ending_time - starting_time;
            int minutes = (rand.Next(0, (int)survey_range.TotalMinutes));
            TimeSpan minutes_added = new TimeSpan(0, minutes, 0);
            TimeSpan random_survey_time = starting_time.Add(minutes_added);
            return random_survey_time;
        }
    }
}

