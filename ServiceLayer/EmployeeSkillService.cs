﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public class EmployeeSkillService
    {
        private GcsContext _context;

        public EmployeeSkillService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<EmployeeSkill> GetEmployeeSkills()
        {
            return _context.EmployeeSkills
                .Include(c=>c.EmployeeLink)
                .Include(c=>c.SkillLink);
        }

        public void AddEmployeeSkill(EmployeeSkill toAddEmpSkill)
        {
	        _context.EmployeeSkills.Add(toAddEmpSkill);
	        _context.SaveChanges();
        }
    }
}
