using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Lab3
{
    public class Schedule
    {
        public List<Record> Records { get; private set; }

        public Schedule()
        {
            Records = ReadRecordsFromFile();
        }

        public List<Record> GetRecordsByDate(DayOfWeek day)
            => Records.Where(record => record.StartDate.DayOfWeek == day).ToList();

        public List<Record> GetRecordsByPlace(string place)
            => Records.Where(record => record.Place == place).ToList();

        public void Clear() 
            => Records.Clear();

        public bool AddRecord(Record record)
        {
            var recordAtSameDay = Records.FirstOrDefault(x =>
                record.StartDate >= x.StartDate && record.StartDate <= x.EndDate
                || record.EndDate >= x.StartDate && record.EndDate <= x.EndDate);

            if (recordAtSameDay != null)
            {
                return false;
            }

            Records.Add(record);
            WriteRecordsToFile();

            return true;
        }

        public bool Replace(int index, Record record)
        {
            if (index < 0 && index >= Records.Count)
            {
                return false;
            }

            Records[index] = record;
            WriteRecordsToFile();

            return true;
        }

        public bool Remove(int index)
        {
            if (index < 0 && index >= Records.Count)
            {
                return false;
            }

            Records.RemoveAt(index);
            WriteRecordsToFile();

            return true;
        }

        public bool Insert(int index, Record record)
        {
            if (index < 0 && index >= Records.Count)
            {
                return false;
            }

            Records.Insert(index,record);
            WriteRecordsToFile();

            return true;
        }

        private void WriteRecordsToFile()
        {
            string json = JsonSerializer.Serialize(Records);
            File.WriteAllText(@"subjects.txt", json);
        }

        private List<Record> ReadRecordsFromFile()
        {
            var json = File.ReadAllText(@"subjects.txt");
            return JsonSerializer.Deserialize<List<Record>>(json);
        }
    }
}
