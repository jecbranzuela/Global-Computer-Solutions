using System;
using System.Collections.ObjectModel;
using System.Linq;
using App1.ViewModels.Employee;
using App1.ViewModels.Skill;
using ServiceLayer;

namespace App1.ViewModels
{
	public class EmployeeListViewModel
	{
		private readonly EmployeeRegionService _employeeRegionService;
		private string _searchText;
		private EmployeeViewModel _selectedEmployee;
		public ObservableCollection<EmployeeViewModel> EmployeeList { get; }
		public ObservableCollection<SkillViewModel> EmployeeSkills { get; set; }

		public EditEmployeeViewModel CreateEditEmployeeViewModel()
		{
			return new EditEmployeeViewModel(_selectedEmployee, _employeeRegionService);
		}

		public EmployeeListViewModel(EmployeeRegionService employeeRegionService)
		{
			EmployeeSkills = new ObservableCollection<SkillViewModel>();
			_employeeRegionService = employeeRegionService;
			EmployeeList = new ObservableCollection<EmployeeViewModel>(
			employeeRegionService.EmployeeService.GetEmployees()
			.Select(c => new EmployeeViewModel(c)));
		}


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
			var skills = _employeeRegionService.EmployeeService.GetSkills(SelectedEmployee.EmployeeId)
			.OrderBy(c => c.Description);

			EmployeeSkills.Clear();

			foreach (var skill in skills) EmployeeSkills.Add(new SkillViewModel(skill));
		}

		private void SearchEmployee(string searchString)
		{
			EmployeeList.Clear();

			var employees = _employeeRegionService.EmployeeService.GetEmployees()
			.Where(c => c.FirstName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));
			//.Where(c => c.FirstName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)
			//|| c.LastName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)
			//|| c.MiddleInitial.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)
			//);

			foreach (var employee in employees)
			{
				var employeeModel = new EmployeeViewModel(employee);
				EmployeeList.Add(employeeModel);
			}
		}
	}
}