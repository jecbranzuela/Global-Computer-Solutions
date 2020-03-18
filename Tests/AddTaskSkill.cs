using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CreateTests
{
    [TestFixture]
    public class AddTaskSkill
    {
        [Test]
        public void TaskSkill_AddTaskSkills()
        {
            using var context = new GcsContext();
            var newTaskSkill = new TaskSkill();
            newTaskSkill.TaskClassId = 1;
            newTaskSkill.TaskClassLink = context.TaskClasses.First(c => c.TaskClassId == newTaskSkill.TaskClassId);
            newTaskSkill.SkillId = 1;
            newTaskSkill.SkillLink = context.Skills.First(c => c.SkillId == newTaskSkill.SkillId);
            context.TaskSkills.Add(newTaskSkill);
            context.SaveChanges();


        }
    }
}
