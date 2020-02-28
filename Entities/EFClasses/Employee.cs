using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfHire { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public ICollection<Project> Projects { get; set; }

        //foreign keys
        public int RegionId { get; set; }
        public Region RegionLink { get; set; }

        //delete status
        public bool IsDeleted { get; set; }

    }
}
