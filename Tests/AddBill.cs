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
    public class AddBill
    {
        [Test]
        public void Bill_AddBill()
        {
            using var context = new GcsContext();
            var newBill = new Bill();
            newBill.TotalHoursWorked = 40;
            newBill.Amount = 490.40f;
            context.Bills.Add(newBill);
            context.SaveChanges();
        }
    }
}
