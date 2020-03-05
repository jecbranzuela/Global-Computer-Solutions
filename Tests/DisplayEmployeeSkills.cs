using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCSClasses;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CreateTests
{
    [TestFixture]
    public class DisplayEmployeeSkills
    {
        [Test]
        public void EmployeeSkills_DisplayEmployeeSkills()
        {
            using var context = new GcsContext();
            var emp = context.Employees.First(c => c.EmployeeId == 1);
            var empSkill = context.EmployeeSkills
                .Where(c=>c.EmployeeId == 1)
                .Include(c => c.EmployeeLink)
                .Include(c => c.SkillLink);

            Console.WriteLine($"The skills of {emp.LastName} with employee id of {emp.EmployeeId}");
            foreach (var employeeSkill in empSkill)
            {
                Console.WriteLine($"{employeeSkill.EmployeeLink.EmployeeId} has skill {employeeSkill.SkillLink.Description}");
            }
        }

        [Test]
        public void EmployeeSkills_DisplayEmployeesWithTheSameSkills()
        {
            using var context = new GcsContext();
            var skills = context.Skills
                .Include(c => c.EmployeeSkills)
                .ThenInclude(c => c.EmployeeLink);
            foreach (var skill in skills)
            {
                Console.WriteLine();
                Console.WriteLine($"list of employees that can do {skill.Description}");
                foreach (var skillEmployeeSkill in skill.EmployeeSkills)
                {
                    Console.WriteLine($"{skillEmployeeSkill.EmployeeLink.LastName}");
                }
            }

            
        }
    }
}
