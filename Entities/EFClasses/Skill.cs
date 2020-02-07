using System.Collections.Generic;

namespace Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Description { get; set; }
        public int RateOfPay { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public ICollection<TaskSkill> TaskSkills { get; set; }
    }
}