using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels.Assignment;
using App1.ViewModels.Employee;
using App1.ViewModels.Skill;
using GCSClasses;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

namespace App1.ViewModels.ProjectSchedule
{
    public class ProjectScheduleTaskListVM
    {
	    private ProjCustEmpRegService _projCustEmpRegService;
	    private ProjectScheduleTaskViewModel _selectedProjectScheduleTask;
	    private SkillViewModel _selectedSkillForTask;
	    public ObservableCollection<ProjectScheduleTaskViewModel> ProjectScheduleTaskList { get; set; }
	    public SkillListViewModel SkillsForScheduledTask { get; set; }
		public EmployeeListViewModel EmployeesAssignedPerTaskSkill { get; set; }
		public ObservableCollection<AssignmentViewModel> AssignmentsPerSkill { get; set; }

		public int ProjectId { get; set; }

	    public ProjectScheduleTaskListVM(ProjCustEmpRegService projCustEmpRegService,
		ObservableCollection<ProjectScheduleTaskViewModel> projectScheduleTaskList,int projectId)
	    {
		    _projCustEmpRegService = projCustEmpRegService;
		    ProjectScheduleTaskList = projectScheduleTaskList;
		    SkillsForScheduledTask = new SkillListViewModel(_projCustEmpRegService.SkillService);
		    EmployeesAssignedPerTaskSkill = new EmployeeListViewModel(_projCustEmpRegService.EmployeeRegionService);
			AssignmentsPerSkill = new ObservableCollection<AssignmentViewModel>();
			AssignmentsPerSkill.Clear();
			EmployeesAssignedPerTaskSkill.EmployeeList.Clear();
			SkillsForScheduledTask.SkillList.Clear();
		    ProjectId = projectId;
	    }

	    public ProjectScheduleTaskViewModel SelectedProjectScheduleTask
	    {
		    get => _selectedProjectScheduleTask;
		    set
		    {
			    _selectedProjectScheduleTask = value;
			    if (_selectedProjectScheduleTask != null)
			    {
				    LoadTaskSkills();
				    AssignmentsPerSkill.Clear();
				}

		    } 
	    }

	    public SkillViewModel SelectedSkillForTask
	    {
		    get => _selectedSkillForTask;
		    set
		    {
			    _selectedSkillForTask = value;
			    if (_selectedSkillForTask != null) LoadAssignmentsPerTaskSkill();
		    }

	    }

	    public ProjCustEmpRegService ReturnContext()
	    {
		    return _projCustEmpRegService;
	    }

		private void LoadTaskSkills()
		{
			var group = _projCustEmpRegService.ProjectScheduleTaskService
			.GetTaskSkills(SelectedProjectScheduleTask.TaskClassId,SelectedProjectScheduleTask.ProjectScheduleTaskId);

			SkillsForScheduledTask.SkillList.Clear();
			foreach (var taskSkill in group) SkillsForScheduledTask.SkillList.Add(new SkillViewModel(taskSkill.SkillLink));
	    }

		private void LoadEmployeesAssignedPerTaskSkill()
		{
			var employees = _projCustEmpRegService.ProjectScheduleTaskService.
			GetEmployeesForTaskSkills(SelectedProjectScheduleTask.TaskClassId, SelectedProjectScheduleTask.ProjectScheduleTaskId);
			employees.Distinct().ToList();
			EmployeesAssignedPerTaskSkill.EmployeeList.Clear();
			foreach (var employee in employees)
				EmployeesAssignedPerTaskSkill.EmployeeList.Add(new EmployeeViewModel(employee));
		}

		private void LoadAssignmentsPerTaskSkill()
		{
			AssignmentsPerSkill.Clear();
			var assignments = _projCustEmpRegService.ProjectScheduleTaskService
			.GetAssignmentsForSelectedTaskSkill(SelectedProjectScheduleTask.TaskClassId,
			SelectedProjectScheduleTask.ProjectScheduleTaskId, 
			SelectedSkillForTask.SkillId);

			assignments = assignments.Distinct().ToList();
			foreach (var assignment in assignments) AssignmentsPerSkill.Add(new AssignmentViewModel(assignment));
		}
    }
}
