using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;

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
                .Where(c=>c.IsDeleted ==false);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void EditCustomer(int customerId, int regionId, string name, int phoneNumber)
        {
            var customer = _context.Customers.Find(customerId);
            customer.RegionId = regionId;
            customer.Name = name;
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
