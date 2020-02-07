using System.Collections.Generic;

namespace Entities
{
    public class Region
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}