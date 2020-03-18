using System;
using System.Collections.Generic;
using GCSClasses.EFClasses;

namespace Entities
{
    public class ProjectScheduleTask
    {
        public int ProjectScheduleTaskId { get; set; }
        //  public int RegionId { get; set; } //region sa customer
        public ICollection<Assignment> Assignments { get; set; }
        public DateTime ScheduledStartDate { get; set; }
        public DateTime ScheduledEndDate { get; set; }
        public ICollection<TaskSkillEmployeesQuantity> TaskSkillEmployeesQuantities { get; set; }

        //foreign keys
        public int ProjectId { get; set; }
        public Project ProjectLink { get; set; }
        public int TaskClassId { get; set; }
        public TaskClass TaskClassLink { get; set; }
    }
}