using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCSClasses;

namespace ServiceLayer
{
    public class ProjCustEmpRegService
    {
        public CustomerRegionService CustomerRegionService { get; }
        public EmployeeRegionService EmployeeRegionService { get; }
        public ProjectService ProjectService { get; set; }

        public ProjCustEmpRegService(GcsContext context)
        {
	        CustomerRegionService = new CustomerRegionService(context);
            EmployeeRegionService = new EmployeeRegionService(context);
            ProjectService = new ProjectService(context);
        }
    }
}
