using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace GCSClasses.EFClasses
{
    public class TaskSkillEmployeesQuantity
    {
        public int TaskSkillEmployeesQuantityId { get; set; }
        public int TaskSkillId { get; set; }
        public int ProjectScheduleTaskId { get; set; }
        public int EmployeesNeeded { get; set; }
        public int EmployeesCurrentlyAssigned { get; set; }

        public TaskSkill TaskSkillLink { get; set; }
        public ProjectScheduleTask ProjectScheduleTaskLink { get; set; }
    }
}
