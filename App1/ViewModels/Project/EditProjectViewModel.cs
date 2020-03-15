using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using App1.Annotations;
using App1.ViewModels.Customer;
using App1.ViewModels.Employee;
using ServiceLayer;

namespace App1.ViewModels.Project
{
	public class EditProjectViewModel : INotifyPropertyChanged
	{
		private ProjCustEmpRegService _projCustEmpRegService;
		public ProjectViewModel AssociatedProjectModel { get;private set; }

		private string _searchEmployeeId;
		private string _searchCustomerId;
		private string _employeeName;
		private string _customerName;

		public int CustomerId { get; set; }
		public int? EmployeeId { get; set; }
		public string Description { get; set; }
		public DateTime EstimatedStartDate { get; set; }
		public DateTime EstimatedEndDate { get; set; }
		public int Budget { get; set; }
		public DateTime Date { get; set; }
		public int? ActualCost { get; set; }
		public DateTime? ActualStartDate { get; set; }
		public DateTime? ActualEndDate { get; set; }


		public string SearchEmployeeId
		{
			get => _searchEmployeeId;
			set
			{
				_searchEmployeeId = value;
				SearchEmployeeWithId(_searchEmployeeId);
			}
		}

		public string SearchCustomerId
		{
			get => _searchCustomerId;
			set
			{
				_searchCustomerId = value;
				SearchCustomerWithId(_searchCustomerId);
			}
		}

		private void SearchCustomerWithId(string searchCustomerId)
		{
			var cust = _projCustEmpRegService.CustomerRegionService.CustomerService.GetCustomers()
			.First(c => c.CustomerId.ToString().Contains(searchCustomerId));
			CustomerName = new CustomerViewModel(cust).FullName;
		}

		private void SearchEmployeeWithId(string searchEmployeeId)
		{
			var emp = _projCustEmpRegService.EmployeeRegionService.EmployeeService.GetEmployees()
			.First(c => c.EmployeeId.ToString().Contains(searchEmployeeId));
			EmployeeName = new EmployeeViewModel(emp).FullName;
		}

		public string EmployeeName
		{
			get => _employeeName;
			set
			{
				_employeeName = value;
				OnPropertyChanged(nameof(EmployeeName));
			}
		}

		public string CustomerName
		{
			get => _customerName;
			set
			{
				_customerName = value;
				OnPropertyChanged(nameof(CustomerName));
			}
		}

		public EditProjectViewModel(ProjectViewModel projectModel,ProjCustEmpRegService projCustEmpRegService)
		{
			AssociatedProjectModel = projectModel;
			_projCustEmpRegService = projCustEmpRegService;

			CopyEditableFields(projectModel);
		}

		private void CopyEditableFields(ProjectViewModel projectModel)
		{
			SearchCustomerId = projectModel.CustomerId.ToString();
			SearchEmployeeId = projectModel.EmployeeId.ToString();
			CustomerId = projectModel.CustomerId;
			EmployeeId = projectModel.EmployeeId;
			Description = projectModel.Description;
			EstimatedStartDate = projectModel.EstimatedStartDate;
			EstimatedEndDate = projectModel.EstimatedEndDate;
			Budget = projectModel.Budget;
			Date = projectModel.Date;
			ActualCost = projectModel.ActualCost;
			ActualStartDate = projectModel.ActualStartDate;
			ActualEndDate = projectModel.ActualEndDate;
		}

		public void Edit()
		{
			CustomerId = Int32.Parse(SearchCustomerId);
			EmployeeId = Int32.Parse(SearchEmployeeId);
			AssociatedProjectModel.CustomerId = CustomerId;
			AssociatedProjectModel.EmployeeId = EmployeeId;
			AssociatedProjectModel.Description = Description;
			AssociatedProjectModel.EstimatedStartDate = EstimatedStartDate;
			AssociatedProjectModel.EstimatedEndDate = EstimatedEndDate;
			AssociatedProjectModel.Budget = Budget;
			AssociatedProjectModel.Date = Date;
			AssociatedProjectModel.ActualCost = ActualCost;
			AssociatedProjectModel.ActualStartDate = ActualStartDate;
			AssociatedProjectModel.ActualEndDate = ActualEndDate;
			_projCustEmpRegService.ProjectService.EditProject(AssociatedProjectModel.ProjectId,
			AssociatedProjectModel.CustomerId, AssociatedProjectModel.EmployeeId, AssociatedProjectModel.EstimatedEndDate,
			AssociatedProjectModel.EstimatedStartDate, AssociatedProjectModel.Description, AssociatedProjectModel.ActualCost,
			AssociatedProjectModel.Budget, AssociatedProjectModel.Date, AssociatedProjectModel.ActualStartDate, AssociatedProjectModel.ActualEndDate

			);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}