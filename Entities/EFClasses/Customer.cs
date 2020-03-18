using System.Collections.Generic;

namespace Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public long PhoneNumber { get; set; }
        public ICollection<Project> Projects { get; set; }


        //foreign key
        public int RegionId { get; set; }
        public Region RegionLink { get; set; }
        public bool IsDeleted { get; set; }
    }
}