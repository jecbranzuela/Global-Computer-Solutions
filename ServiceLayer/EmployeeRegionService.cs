using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;

namespace ServiceLayer
{
    public class EmployeeRegionService
    {
	    public EmployeeService EmployeeService { get;}
	    public RegionService RegionService { get;}
		public SkillService SkillService { get; }
		public EmployeeSkillService EmployeeSkillService { get; }

	    public EmployeeRegionService(GcsContext context)
	    {
		    EmployeeService = new EmployeeService(context);
		    RegionService = new RegionService(context);
		    SkillService = new SkillService(context);
		    EmployeeSkillService = new EmployeeSkillService(context);


		}
    }
}
