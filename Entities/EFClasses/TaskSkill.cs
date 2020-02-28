using GCSClasses.EFClasses;

namespace Entities
{
    public class TaskSkill
    {
        public int TaskSkillId { get; set; }
        public int NumberOfEmployeesNeeded { get; set; }

        //foreign keys
        public int SkillId { get; set; }
        public Skill SkillLink { get; set; }
        public int TaskClassId { get; set; }
        public TaskClass TaskClassLink { get; set; }
    }
}