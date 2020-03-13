using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using App1.Annotations;
using App1.ViewModels.Customer;
using App1.ViewModels.Employee;
using App1.ViewModels.Region;

namespace App1.ViewModels.Project
{
	public class ProjectViewModel : INotifyPropertyChanged
	{
		private int? _actualCost;
		private DateTime? _actualEndDate;
		private DateTime? _actualStartDate;
		private int _budget;
		private int _customerId;
		private string _customerName;
		private DateTime _date; //contract sign date, default value of datepicker should be datetime.Now
		private string _description;
		private int? _employeeId;
		[CanBeNull] private string _employeeName;
		private DateTime _estimatedEndDate;
		private DateTime _estimatedStartDate;
		private string _region;

		private int _projectId;

		public ProjectViewModel(Entities.Project project)
		{
			ProjectId = project.ProjectId;
			Description = project.Description;
			Date = project.Date;
			EstimatedStartDate = project.EstimatedStartDate;
			EstimatedEndDate = project.EstimatedEndDate;
			Budget = project.Budget;
			ActualStartDate = project.ActualStartDate;
			ActualEndDate = project.ActualEndDate;
			ActualCost = project.ActualCost;
			CustomerId = project.CustomerId;
			CustomerName = new CustomerViewModel(project.CustomerLink).FullName;
			EmployeeId = project.EmployeeId;
			EmployeeName = new EmployeeViewModel(project.EmployeeLink).FullName;
			Region = project.CustomerLink.RegionLink.Name;
		}

		public string Region
		{
			get => _region;
			set
			{
				_region = value;
				OnPropertyChanged(nameof(Region));
			}
		}

		public int ProjectId
		{
			get => _projectId;
			set
			{
				_projectId = value;
				OnPropertyChanged(nameof(ProjectId));
			}
		}

		public string Description
		{
			get => _description;
			set
			{
				_description = value;
				OnPropertyChanged(nameof(Description));
			}
		}

		public DateTime Date
		{
			get => _date;
			set
			{
				_date = value;
				OnPropertyChanged(nameof(Date));
			}
		}

		public DateTime EstimatedStartDate
		{
			get => _estimatedStartDate;
			set
			{
				_estimatedStartDate = value;
				OnPropertyChanged(nameof(EstimatedStartDate));
			}
		}

		public DateTime EstimatedEndDate
		{
			get => _estimatedEndDate;
			set
			{
				_estimatedEndDate = value;
				OnPropertyChanged(nameof(EstimatedEndDate));
			}
		}

		public int Budget
		{
			get => _budget;
			set
			{
				_budget = value;
				OnPropertyChanged(nameof(Budget));
			}
		}

		public DateTime? ActualStartDate
		{
			get => _actualStartDate;
			set
			{
				_actualStartDate = value;
				OnPropertyChanged(nameof(ActualStartDate));
			}
		}

		public DateTime? ActualEndDate
		{
			get => _actualEndDate;
			set
			{
				_actualEndDate = value;
				OnPropertyChanged(nameof(ActualEndDate));
			}
		}

		public int? ActualCost
		{
			get => _actualCost;
			set
			{
				_actualCost = value;
				OnPropertyChanged(nameof(ActualCost));
			}
		}

		public int CustomerId
		{
			get => _customerId;
			set
			{
				_customerId = value;
				OnPropertyChanged(nameof(CustomerId));
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

		public int? EmployeeId
		{
			get => _employeeId;
			set
			{
				_employeeId = value;
				OnPropertyChanged(nameof(EmployeeId));
			}
		}

		[CanBeNull]
		public string EmployeeName
		{
			get => _employeeName;
			set
			{
				_employeeName = value;
				OnPropertyChanged(nameof(EmployeeName));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}