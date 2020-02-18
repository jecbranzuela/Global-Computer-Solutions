using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;
using NUnit.Framework;

namespace CreateTests
{
    [TestFixture]
    public class AddEmployee
    {
        [Test]
        public void Employee_AddEmployeeAutoGenerateId()
        {
            using var context = new GcsContext();
            var newEmp = new Employee();
            newEmp.FirstName = "Qwerty";
            newEmp.LastName = "Uiop";
            newEmp.MiddleInitial = "D.";
            newEmp.RegionId = 1;
            newEmp.RegionLink = context.Regions.First(c => c.RegionId == 1);
            context.Employees.Add(newEmp);
            context.SaveChanges();
            Console.WriteLine($"{newEmp.FirstName} {newEmp.MiddleInitial} {newEmp.LastName} " +
                              $"is from {newEmp.RegionLink.Name}");
        }
    }
}
