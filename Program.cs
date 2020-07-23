using System;

namespace TimeConverterNS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            DateTime survey = new DateTime(2010, 6, 13, 18, 32, 0);
            DateTime response = new DateTime(2010, 6, 13, 20, 01, 34);
            TimeSpan start = new TimeSpan(7, 0, 0);
            TimeSpan end = new TimeSpan(18, 0, 0);

            Console.WriteLine(TimeConverter.ConvertToEastern("00:00", "Mountain Standard Time"));
            Console.WriteLine(TimeConverter.IsTodayInList("0,1,2,3,4"));
            Console.WriteLine(TimeConverter.IsMessageRespondingToSurvey(survey, response));
            Console.WriteLine(TimeConverter.GenerateRandomTime(start, end));
        }

    }

}
