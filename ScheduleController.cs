using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lab3
{
    public class ScheduleController
    {
        private Schedule _schedule;

        public ScheduleController(Schedule schedule)
        {
            _schedule = schedule;
        }

        public void GetRecordsByDate()
        {
            Console.WriteLine("Enter day of week: \nMonday - 1\nTuesday - 2\nWednesday - 3\nThursday - 4\nFriday - 5");
            var dayOfWeek = (DayOfWeek)Convert.ToInt32(Console.ReadLine());
            var result = _schedule.GetRecordsByDate(dayOfWeek);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.StartDate.DayOfWeek} {item.StartDate.TimeOfDay} " +
                    $"{item.EndDate.TimeOfDay} {item.Place}" +
                    $" {item.Subject}");
            }
        }

        public void GetRecordsByPlace() 
        {
            Console.WriteLine("Enter place: ");
            string place = Console.ReadLine();
            var result = _schedule.GetRecordsByPlace(place);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.StartDate.DayOfWeek} {item.StartDate.TimeOfDay} " +
                    $"Duration:{item.EndDate.TimeOfDay - item.StartDate.TimeOfDay } {item.Place}" +
                    $" {item.Subject}");
            }
        }

        public void Clear()
        {
            Console.WriteLine("Are you sure to clear records ?");
            string answer = Console.ReadLine();

            if (answer == "Yes")
            {
                _schedule.Clear();
            }
        }
         public void AddRecord()
         {
            var record = GetNewRecord();

            string res = _schedule.AddRecord(record) ? "Addition was successful" : "Something went wrong";
            Console.WriteLine(res);
         }

        public void Replace()
        {
            Console.WriteLine("Enter index, which you want to replace");
            int index = Convert.ToInt32(Console.ReadLine());

            var record = GetNewRecord();
            string res = _schedule.Replace(index,record) ? "Replacing was successful" : "Something went wrong";
            Console.WriteLine(res);
        }

        public void Insert()
        {
            Console.WriteLine("Enter index, where you want to insert ");
            int index = Convert.ToInt32(Console.ReadLine());

            var record = GetNewRecord();
            string res = _schedule.Insert(index, record) ? "Inserting was successful" : "Something went wrong";
            Console.WriteLine(res);
        }

        public void Remove()
        {
            Console.WriteLine("Enter index, which you want to remove ");
            int index = Convert.ToInt32(Console.ReadLine());

            string res = _schedule.Remove(index) ? "Removing was successful" : "Something went wrong";
            Console.WriteLine(res);
        }

        public void PrintAllRecords()
        {
            foreach (var record in _schedule.Records)
            {
                Console.WriteLine($"{record.StartDate.DayOfWeek} {record.StartDate.TimeOfDay} " +
                  $"{record.EndDate.TimeOfDay} {record.Place}" +
                  $" {record.Subject}");
            }
        }

        private DateTime InputDateTime()
        {
            Console.Write("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Month: ");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Day: ");
            int day = Convert.ToInt32(Console.ReadLine());

            Console.Write("Hour: ");
            int hour = Convert.ToInt32(Console.ReadLine());

            Console.Write("Minute: ");
            int minute = Convert.ToInt32(Console.ReadLine());

            Console.Write("Second: ");
            int second = Convert.ToInt32(Console.ReadLine());

            return new DateTime(year, month, day, hour, minute, second);
        }

        private Record GetNewRecord()
        {
            Console.WriteLine("Enter record: ");
           
            var startTime = InputDateTime();

            var endTime = InputDateTime();

            Console.WriteLine("Enter place: ");
            string place = Console.ReadLine();

            Console.WriteLine("Enter subject: ");
            string subject = Console.ReadLine();

            return new Record(startTime, endTime, place, subject);
        }
    }
}
