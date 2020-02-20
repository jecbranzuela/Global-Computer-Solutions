using System.Collections.Generic;

namespace Entities
{
    public class Bill
    {
        public int BillId { get; set; }
        public int TotalHoursWorked { get; set; }
        public float Amount { get; set; }
        public ICollection<WorkLog> WorkLogs { get; set; }

        //foreign key
        public int ProjectId { get; set; }
        public Project ProjectLink { get; set; }
    }
}