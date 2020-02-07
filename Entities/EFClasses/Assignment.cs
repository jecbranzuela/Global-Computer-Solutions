using System;
using System.Collections.Generic;

namespace Entities
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectScheduleTaskId { get; set; }
        public int RegionId { get; set; } //region id sa customer
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<WorkLog> WorkLogs { get; set; }
    }
}