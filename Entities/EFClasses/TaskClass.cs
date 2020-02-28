using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace GCSClasses.EFClasses
{
    public class TaskClass
    {
        public int TaskClassId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<TaskSkill> TaskSkills { get; set; }
    }
}
