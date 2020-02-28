using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;

namespace ServiceLayer
{
    public class SkillService
    {
        private GcsContext _context;

        public SkillService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<Skill> GetSkills()
        {
            return _context.Skills;
        }
    }
}
