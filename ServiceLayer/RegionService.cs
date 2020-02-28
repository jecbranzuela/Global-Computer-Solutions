using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;

namespace ServiceLayer
{
    public class RegionService
    {
        private GcsContext _context;

        public RegionService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<Region> GetRegions()
        {
            return _context.Regions;
        }
    }
}
