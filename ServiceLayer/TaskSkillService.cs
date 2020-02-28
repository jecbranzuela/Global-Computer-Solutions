using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;

namespace ServiceLayer
{
    public class TaskSkillService
    {
        private GcsContext _context;

        public TaskSkillService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<TaskSkill> GetTaskSkills()
        {
            return _context.TaskSkills;
        }
    }
}
