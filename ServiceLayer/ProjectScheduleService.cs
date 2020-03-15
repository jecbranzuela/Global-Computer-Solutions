using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;

namespace ServiceLayer
{
    public class ProjectScheduleService
    {
        private GcsContext _context;

        public ProjectScheduleService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<ProjectSchedule> GetProjectSchedules()
        {
            return _context.ProjectSchedules;
        }

        //public IList<Employee> GetAvailableEmployeesForTask()
        //{
        //    var tasks = 
        //}
    }
}
