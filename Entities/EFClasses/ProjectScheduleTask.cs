using System.Collections.Generic;

namespace Entities
{
    public class ProjectScheduleTask
    {
        public int ProjectScheduleTaskId { get; set; }
        public int ProjectSchedule { get; set; }
        public int RegionId { get; set; } //region sa customer
        public ICollection<Assignment> Assignments { get; set; }
    }
}