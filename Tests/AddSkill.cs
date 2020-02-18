using System;
using Entities;
using GCSClasses;
using NUnit.Framework;

namespace CreateTests
{
    [TestFixture]
    public class AddSkill
    {
        [Test]
        public void Skill_AddNewSkillWithAutoGenerateId()
        {
            using var context = new GcsContext();
            var newSkill = new Skill();
            newSkill.Description = "data entry II";
            newSkill.RateOfPay = 10;

            context.Skills.Add(newSkill);
            context.SaveChanges();

            Console.WriteLine($"The skill id of {newSkill.Description} is {newSkill.SkillId}");
        }
    }
}
