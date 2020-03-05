using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class SkillService
    {
        private GcsContext _context;

        public SkillService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<Skill> GetSkills()
        {
            return _context.Skills
                .Include(c=>c.EmployeeSkills)
                .ThenInclude(c=>c.EmployeeLink)
                .ThenInclude(c=>c.RegionLink);
        }

        public IList<Employee> GetEmployees(int skillId)
        {
            var empSkills = _context.EmployeeSkills
                .Where(c => c.SkillId == skillId)
                .Include(c => c.EmployeeLink)
                .ThenInclude(c=>c.RegionLink);
            
            var empList = new List<Employee>();
            foreach (var empSkill in empSkills)
            {
                empList.Add(empSkill.EmployeeLink);
            }

            return empList;
        }

        public void AddSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
        }
    }
}
