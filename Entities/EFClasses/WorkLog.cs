using System;

namespace Entities
{
    public class WorkLog
    {
        public int WorkLogId { get; set; }
        public DateTime Date { get; set; }
        public int TotalHoursWorked { get; set; }

        //foreign keys
        public int AssignmentId { get; set; }
        public Project AssignmentLink { get; set; }
        public int BillId { get; set; }
        public Bill BillLink { get; set; }

    }
}