namespace Entities
{
    public class EmployeeSkill
    {
        public int EmployeeSkillId { get; set; }
        
        //foreign keys
        public int EmployeeId { get; set; }
        public Employee EmployeeLink { get; set; }
        public int SkillId { get; set; }
        public Skill SkillLink { get; set; }

    }
}