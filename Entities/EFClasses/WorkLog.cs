using System;

namespace Entities
{
    public class WorkLog
    {
        public int WorkLogId { get; set; }
        public int AssignmentId { get; set; }
        public int BillId { get; set; }
        public DateTime Date { get; set; }
        public int TotalHoursWorked { get; set; }

    }
}