using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;

namespace ServiceLayer
{
    public class ProjectScheduleTaskService
    {
        private GcsContext _context;

        public ProjectScheduleTaskService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<ProjectScheduleTask> GetProjectScheduleTasks()
        {
            return _context.ProjectScheduleTasks;
        }
    }
}
