using System;
using System.Collections.Generic;

namespace Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        //public int RegionId { get; set; } //region Id sa customer
        public string Description { get; set; }
        public DateTime Date { get; set; } //date contract signed
        public DateTime EstimatedStartDate { get; set; }
        public DateTime EstimatedEndDate { get; set; }
        public int Budget { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualEndDate { get; set; }
        public int ActualCost { get; set; }
        public ICollection<ProjectSchedule> ProjectSchedules { get; set; }
        public ICollection<Bill> Bills { get; set; }

        //foreign keys
        public int EmployeeId { get; set; } //manager
        public Employee EmployeeLink { get; set; }
        public int CustomerId { get; set; }
        public Customer CustomerLink { get; set; }
        public bool IsDeleted { get; set; }
    }
}