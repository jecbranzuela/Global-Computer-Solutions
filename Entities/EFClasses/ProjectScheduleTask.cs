using System.Collections.Generic;
using GCSClasses.EFClasses;

namespace Entities
{
    public class ProjectScheduleTask
    {
        public int ProjectScheduleTaskId { get; set; }
        //  public int RegionId { get; set; } //region sa customer
        public ICollection<Assignment> Assignments { get; set; }

        //foreign keys
        public int ProjectScheduleId { get; set; }
        public ProjectSchedule ProjectScheduleLink { get; set; }
        public int TaskClassId { get; set; }
        public TaskClass TaskClassLink { get; set; }
    }
}