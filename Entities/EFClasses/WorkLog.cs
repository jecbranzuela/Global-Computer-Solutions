using System;

namespace Entities
{
    public class WorkLog
    {
        public int WorkLogId { get; set; }
        public DateTime Date { get; set; }
        public int TotalHoursWorked { get; set; }

        //foreign keys
        public int ProjectId { get; set; }
        public Project ProjectLink { get; set; }
        public int BillId { get; set; }
        public Bill BillLink { get; set; }

    }
}