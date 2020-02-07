﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int RegionId { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfHire { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
