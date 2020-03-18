using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels.Skill;
using ServiceLayer;

namespace App1.ViewModels.Employee
{
    public class EmployeeSkillsListViewModel
    {
	    private EmployeeRegionService _employeeRegionService;
	    public ObservableCollection<EmployeeSkillViewModel> EmployeeSkillList { get; set; }

	    public int EmployeeId { get; set; }

	    public EmployeeSkillsListViewModel(EmployeeRegionService employeeRegionService,
	    ObservableCollection<EmployeeSkillViewModel> employeeSkills,
	    int selectedEmployeeEmployeeId)
	    {
		    _employeeRegionService = employeeRegionService;
		    EmployeeSkillList = employeeSkills;
		    EmployeeId = selectedEmployeeEmployeeId;
	    }

	    public EmployeeRegionService ReturnContext()
	    {
		    return _employeeRegionService;
	    }
    }
}
