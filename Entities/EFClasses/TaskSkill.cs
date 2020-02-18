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
        public int TaskId { get; set; }
        public Task TaskLink { get; set; }
    }
}