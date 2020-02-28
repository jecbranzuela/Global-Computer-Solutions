using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;

namespace ServiceLayer
{
    public class BillService
    {
        private GcsContext _context;

        public BillService(GcsContext context)
        {
            _context = context;
        }

        public IQueryable<Bill> GetBills()
        {
            return _context.Bills;
        }
    }
}
