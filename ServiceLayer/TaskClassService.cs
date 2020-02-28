using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;
using GCSClasses.EFClasses;

namespace ServiceLayer
{
    public class TaskClassService
    {
        private GcsContext _context;

        public TaskClassService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<TaskClass> GetTasks()
        {
            return _context.TaskClasses;
        }
    }
}
