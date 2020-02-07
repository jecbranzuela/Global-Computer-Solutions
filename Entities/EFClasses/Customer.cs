using System.Collections.Generic;

namespace Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}