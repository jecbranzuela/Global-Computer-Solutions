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
    public class CustomerService
    {
        private GcsContext _context;

        public CustomerService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _context.Customers
                .Where(c=>c.IsDeleted ==false)
            .Include(c=>c.RegionLink);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void EditCustomer(int customerId, int regionId, string firstName, string middleInitial,string lastName,int phoneNumber)
        {
            var customer = _context.Customers.Find(customerId);
            customer.RegionId = regionId;
            customer.FirstName = firstName;
            customer.MiddleInitial = middleInitial;
            customer.LastName = lastName;
            customer.PhoneNumber = phoneNumber;
            customer.RegionLink = _context.Regions.First(c => c.RegionId == customer.RegionId);

            _context.SaveChanges();
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            customer.IsDeleted = true;
        }
    }
}
