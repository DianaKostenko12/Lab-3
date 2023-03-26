using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Record
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Place { get; set; }
        public string Subject { get; set; }
        public Record(DateTime startDate, DateTime endDate, string place, string subject)
        {
            StartDate = startDate;
            EndDate = endDate;
            Place = place;
            Subject = subject;
        }
    }
}
