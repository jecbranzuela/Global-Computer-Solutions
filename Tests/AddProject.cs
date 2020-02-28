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
    public class AddProject
    {
        [Test]
        public void Project_AddProjectAutogenerateId()
        {
            using var context = new GcsContext();
            var newProj = new Project();
            newProj.Description = "Project 9999";
            newProj.ActualEndDate = DateTime.Now;
            newProj.ActualStartDate = DateTime.Now;
            newProj.EstimatedEndDate = DateTime.Now;
            newProj.EstimatedStartDate = DateTime.Now;
            newProj.Budget = 450000;
            newProj.ActualCost = 350000;
            newProj.EmployeeId = 1;
            newProj.EmployeeLink = context.Employees.First(c => c.EmployeeId == newProj.EmployeeId);
            newProj.CustomerId = 1;
            newProj.CustomerLink = context.Customers.First(c => c.CustomerId == newProj.CustomerId);
            newProj.Date = DateTime.Now;


            context.Projects.Add(newProj);
            context.SaveChanges();
        }
        
    }
}
