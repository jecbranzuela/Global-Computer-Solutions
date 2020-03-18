using System;
using System.Collections.ObjectModel;
using System.Linq;
using App1.ViewModels.Employee;
using App1.ViewModels.Skill;
using Entities;
using GCSClasses;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

namespace App1.ViewModels
{
	public class EmployeeListViewModel
	{
		private readonly EmployeeRegionService _employeeRegionService;
		private string _searchText;
		private EmployeeViewModel _selectedEmployee;
		public ObservableCollection<EmployeeViewModel> EmployeeList { get; }
		public ObservableCollection<EmployeeSkillViewModel> EmployeeSkills { get; set; }

		public EditEmployeeViewModel CreateEditEmployeeViewModel()
		{
			return new EditEmployeeViewModel(_selectedEmployee, _employeeRegionService);
		}

		public EmployeeListViewModel(EmployeeRegionService employeeRegionService)
		{
			_employeeRegionService = employeeRegionService;
			EmployeeList = new ObservableCollection<EmployeeViewModel>(
			_employeeRegionService.EmployeeService.GetEmployees()
			.Include(c=>c.RegionLink)
			.Select(c => new EmployeeViewModel(c))
			);

			EmployeeSkills = new ObservableCollection<EmployeeSkillViewModel>();
		}

		//public void ReloadEmployeeList()
		//{
		//	EmployeeList.Clear();
		//	var context = new EmployeeService(new GcsContext());
		//	var employees = context.GetEmployees()
		//	.Include(c => c.RegionLink)
		//	.Select(c => new EmployeeViewModel(c));

		//	foreach (var employeeViewModel in employees) EmployeeList.Add(employeeViewModel);

		//}

		public EmployeeViewModel SelectedEmployee
		{
			get => _selectedEmployee;
			set
			{
				_selectedEmployee = value;
				LoadEmployeeSkills();
			}
		}

		public string SearchText
		{
			get => _searchText;
			set
			{
				_searchText = value;
				SearchEmployee(_searchText);
			}
		}

		private void LoadEmployeeSkills()
		{
			var empSkills = _employeeRegionService.EmployeeService
			.GetEmployeeSkills(SelectedEmployee.EmployeeId)
			.Distinct();
			EmployeeSkills.Clear();
			foreach (var employeeSkill in empSkills)
			{
				EmployeeSkills.Add(new EmployeeSkillViewModel(employeeSkill));
			}
		}

		public EmployeeSkillsListViewModel EmpSkill()
		{
			return new EmployeeSkillsListViewModel(_employeeRegionService,EmployeeSkills,SelectedEmployee.EmployeeId);
		}
		private void SearchEmployee(string searchString)
		{
			EmployeeList.Clear();

			var employees = _employeeRegionService.EmployeeService.GetEmployees()
			.Where(c => c.FirstName.Contains(searchString)
			||c.RegionLink.Name.Contains(searchString)
			||c.MiddleInitial.Contains(searchString)
			||c.LastName.Contains(searchString)
			||c.EmployeeId.ToString().Contains(searchString)
			);

			foreach (var employee in employees)
			{
				var employeeModel = new EmployeeViewModel(employee);
				EmployeeList.Add(employeeModel);
			}
		}
	}
}