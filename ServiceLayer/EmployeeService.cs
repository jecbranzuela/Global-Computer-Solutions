using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;

namespace ServiceLayer
{
    public class EmployeeService
    {
        private GcsContext _context;

        public EmployeeService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<Employee> GetEmployees()
        {
            return _context.Employees
                .Where(c=>c.IsDeleted==false);
        }

        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void EditEmployee(int employeeId, int regionId, string firstName, string lastName, string middleInitial)
        {
            //using var context = new GcsContext();
            var employee = _context.Employees.Find(employeeId);
            employee.RegionId = regionId;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.MiddleInitial = middleInitial;
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
