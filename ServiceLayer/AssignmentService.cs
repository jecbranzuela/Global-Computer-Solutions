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
    public class AssignmentService
    {
        private GcsContext _context;

        public AssignmentService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<Assignment> GetAssignments()
        {
            return _context.Assignments;
        }
    }
}
