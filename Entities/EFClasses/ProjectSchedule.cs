using System.Collections.Generic;

namespace Entities
{
    public class ProjectSchedule
    {
        public int ProjectScheduleId { get; set; }
        // public int RegionId { get; set; } //region sa customer
        public ICollection<ProjectScheduleTask> ProjectScheduleTasks { get; set; }

        //foreign keys
        public int ProjectId { get; set; }
        public Project ProjectLink { get; set; }

    }
}