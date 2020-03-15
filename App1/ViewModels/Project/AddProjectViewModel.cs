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
	public class AddProjectViewModel : INotifyPropertyChanged
	{
		private ProjCustEmpRegService _projCustEmpRegService;
		private readonly ProjectListViewModel _projectListViewModel;
		private string _searchText;
		private string _customerName;	
		//public string Description { get; set; }
		//public DateTime EstimatedStartDate { get; set; }
		//public DateTime EstimatedEndDate { get; set; }
		//public int Budget { get; set; }
		//public DateTime ContractSignDate { get; set; }
		public ProjectViewModel AddProjectModel { get; private set; }

		public string CustomerName
		{
			get => _customerName;
			set
			{
				_customerName = value;
				OnPropertyChanged(nameof(CustomerName));
			}
		}

		public AddProjectViewModel(ProjectListViewModel projectListViewModel, ProjCustEmpRegService projCustEmpReg)
		{
			AddProjectModel = new ProjectViewModel();
			_projCustEmpRegService = projCustEmpReg;
			_projectListViewModel = projectListViewModel;
		}

		public string SearchText
		{
			get => _searchText;
			set
			{
				_searchText = value;
				SearchCustomerId(_searchText);
			}
		}

		private void SearchCustomerId(string searchText)
		{
			var cust = _projCustEmpRegService.CustomerRegionService.CustomerService.GetCustomers()
			.First(c => c.CustomerId.ToString().Contains(searchText));
			CustomerName = new CustomerViewModel(cust).FullName;
		}

		public void Add()
		{
			var toAddProj = new Entities.Project();
			AddProjectModel.CustomerId = int.Parse(SearchText);
			AddProjectModel.CustomerName = CustomerName;
			toAddProj.CustomerId = AddProjectModel.CustomerId;
			toAddProj.EmployeeId = AddProjectModel.EmployeeId;
			toAddProj.ActualCost = AddProjectModel.ActualCost;
			toAddProj.Budget = AddProjectModel.Budget;
			toAddProj.EstimatedStartDate = AddProjectModel.EstimatedStartDate;
			toAddProj.EstimatedEndDate = AddProjectModel.EstimatedEndDate;
			toAddProj.ActualCost = AddProjectModel.ActualCost;
			toAddProj.ActualStartDate = AddProjectModel.ActualStartDate;
			toAddProj.ActualEndDate = AddProjectModel.ActualEndDate;
			toAddProj.Date = AddProjectModel.Date;
			toAddProj.Description = AddProjectModel.Description;
			_projCustEmpRegService.ProjectService.AddProject(toAddProj);
			_projectListViewModel.ProjectList.Insert(0,AddProjectModel);
			AddProjectModel.ProjectId = toAddProj.ProjectId;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}