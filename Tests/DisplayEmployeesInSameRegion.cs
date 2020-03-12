using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCSClasses;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CreateTests
{
    [TestFixture]
    public class DisplayEmployeesInSameRegion
    {
        [Test]
        public void Region_DisplayEmployeesInSameRegion()
        {
            using var context = new GcsContext();
            var namesBy = context.Employees
                .Where(c => c.RegionId == 3)
                .Include(c => c.RegionLink)
                .ToList()
                .GroupBy(c => c.LastName.Substring(0,1))
                ;

            foreach (var name in namesBy)
            {
                Console.WriteLine(name.Key);
                foreach (var employee in name)
                {
                    Console.WriteLine($"{employee.LastName} belongs to {employee.RegionLink.Name}");
                }
            }


            //foreach (var employee in emp)
            //{
            //    Console.WriteLine($"{employee.LastName} belongs to {employee.RegionLink.Name}");
            //}
        }
    }
}
