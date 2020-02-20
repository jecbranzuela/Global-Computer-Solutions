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
        public void AddCustomer_AddCustomerAutoGenerateId()
        {
            using var context= new GcsContext();
            var newCust = new Customer();
            newCust.Name = "Qwerty D. Uiop";
            newCust.PhoneNumber = 01234567890;
            newCust.RegionId = 1;
            newCust.RegionLink = context.Regions.First(c => c.RegionId == newCust.RegionId);
            context.Customers.Add(newCust);
            context.SaveChanges();
        }
    }
}
