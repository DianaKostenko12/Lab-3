using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Schedule schedule = new Schedule();

            ScheduleController scheduleController = new ScheduleController(schedule);
            Console.WriteLine("What do you want to do? " +
                "\n 1 - Look the schedule " +
                "\n 2 - Clear the schedule " +
                "\n 3 - Add a new record" +
                "\n 4 - Replace an existing record " +
                "\n 5 - Remove a record " +
                "\n 6 - Insert a new record" +
                "\n 7 - Look duration");

            while (true)
            {
                int choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        scheduleController.GetRecordsByDate();
                        break;
                    case 2:
                        scheduleController.Clear();
                        break;
                    case 3:
                        scheduleController.AddRecord();
                        break;
                    case 4:
                        scheduleController.PrintAllRecords();
                        scheduleController.Replace();
                        break;
                    case 5:
                        scheduleController.PrintAllRecords();
                        scheduleController.Remove();
                        break;
                    case 6:
                        scheduleController.PrintAllRecords();
                        scheduleController.Insert();
                        break;
                    case 7:
                        scheduleController.GetRecordsByPlace();
                        break;
                }

                Console.Clear();
            }
        }
    }
}

