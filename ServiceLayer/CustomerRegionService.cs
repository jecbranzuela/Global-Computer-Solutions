using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCSClasses;

namespace ServiceLayer
{
    public class CustomerRegionService
    {
		public CustomerService CustomerService { get; }
		public RegionService RegionService { get; }

		public CustomerRegionService(GcsContext context)
		{
			CustomerService = new CustomerService(context);
			RegionService = new RegionService(context);
		}
	}
}
