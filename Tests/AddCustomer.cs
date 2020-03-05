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
    public class AddCustomer
    {
        [Test]
        public void Customer_AddCustomerAutoGenerateId()
        {
            using var context= new GcsContext();
            var newCust = new Customer();
            newCust.FirstName = "Hello";
            newCust.MiddleInitial = "D.";
            newCust.LastName = "World";
            newCust.PhoneNumber = 22018;
            newCust.RegionId = 4;
            newCust.RegionLink = context.Regions.First(c => c.RegionId == newCust.RegionId);
            context.Customers.Add(newCust);
            context.SaveChanges();
        }
    }
}
