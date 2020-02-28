﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCSClasses;
using NUnit.Framework;

namespace CreateTests
{
    [TestFixture]
    public class DisplayEmployees
    {
        [Test]
        public void Employee_DisplayEmployees()
        {
            using var context = new GcsContext();
            var emps = context.Employees.Where(c => c.IsDeleted == false);

            foreach (var employee in emps)
            {
                Console.WriteLine($"{employee.FirstName} {employee.MiddleInitial}. {employee.LastName} is from region {employee.RegionLink.Name}");
            }

        }
    }
}
