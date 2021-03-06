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
    public class EmployeeService
    {
        private GcsContext _context;

        public EmployeeService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<Entities.Employee> GetEmployees()
        {
            return _context.Employees
                .Where(c=>c.IsDeleted==false)
                .Include(c=>c.RegionLink);
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public IList<Skill> GetSkills(int employeeId)
        {
	        var empSkills = _context.EmployeeSkills
	        .Where(c => c.EmployeeId == employeeId)
	        .Include(c => c.SkillLink);

	        var skillList = new List<Skill>();
	        foreach (var empSkill in empSkills)
	        {
		        skillList.Add(empSkill.SkillLink);
	        }
				
	        return skillList;
        }

        public IQueryable<EmployeeSkill> GetEmployeeSkills(int employeeId)
        {
            return _context.EmployeeSkills
            .Where(c => c.EmployeeId == employeeId)
            .Include(c=>c.EmployeeLink)
            .Include(c => c.SkillLink);
        }
        public void EditEmployee(int employeeId, int regionId, string firstName, string lastName, string middleInitial,DateTime dateOfHire)
        {
            //using var context = new GcsContext();
            var employee = _context.Employees.Find(employeeId);
            employee.RegionId = regionId;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.MiddleInitial = middleInitial;
            employee.DateOfHire = dateOfHire;
            employee.RegionLink = _context.Regions.First(c => c.RegionId == employee.RegionId);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees.Find(employeeId);
            employee.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
