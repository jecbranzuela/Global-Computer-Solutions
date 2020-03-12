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
    public class RegionService
    {
        private GcsContext _context;

        public RegionService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<Region> GetRegions()
        {
            return _context.Regions
                    .Include(c=>c.Employees)
                    .ThenInclude(c=>c.RegionLink)
                ;
        }

        public IQueryable<Employee> GetEmployees(int regionId)
        {
            return _context.Employees
                .Where(c => c.RegionId == regionId);
        }

        public IQueryable<Customer> GetCustomers(int regionId)
        {
            return _context.Customers
                .Where(c => c.RegionId == regionId);
        }

        //public IList<Employee> GetEmp(int regionId)
        //{
        //    var emp = _context.Employees
        //        .Where(c => c.RegionLink.RegionId == regionId);
        //    var empList =new List<Employee>();

        //    foreach (var employee in emp)
        //    {
        //        empList.Add(employee);
        //    }

        //    return empList;
        //}
    }
}
