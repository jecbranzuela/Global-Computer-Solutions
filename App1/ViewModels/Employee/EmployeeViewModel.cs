using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using App1.Annotations;

namespace App1.ViewModels.Employee
{
	public class EmployeeViewModel : INotifyPropertyChanged
	{
		private DateTime _dateOfHire;
		private int _employeeId;
		private string _firstName;
		private string _lastName;
		private string _middleInitial;
		private string _region;
		private int _regionId;

		public EmployeeViewModel(Entities.Employee employee)
		{
			EmployeeId = employee.EmployeeId;
			LastName = employee.LastName;
			MiddleInitial = employee.MiddleInitial;
			FirstName = employee.FirstName;
			RegionId = employee.RegionId;
			Region = employee.RegionLink.Name;
			DateOfHire = employee.DateOfHire;
			FullName = $"{_lastName},  {_firstName}  {_middleInitial}.";
		}

		public EmployeeViewModel()
		{
		}

		public string FullName { get; set; }

		public int EmployeeId
		{
			get => _employeeId;
			set
			{
				_employeeId = value;
				OnPropertyChanged(nameof(EmployeeId));
			}
		}

		public string LastName
		{
			get => _lastName;
			set
			{
				_lastName = value;
				OnPropertyChanged(nameof(LastName));
			}
		}

		public string MiddleInitial
		{
			get => _middleInitial;
			set
			{
				_middleInitial = value;
				OnPropertyChanged(nameof(MiddleInitial));
			}
		}

		public string FirstName
		{
			get => _firstName;
			set
			{
				_firstName = value;
				OnPropertyChanged(nameof(FirstName));
			}
		}

		public DateTime DateOfHire
		{
			get => _dateOfHire;
			set
			{
				_dateOfHire = value;
				OnPropertyChanged(nameof(DateOfHire));
			}
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

		public int RegionId
		{
			get => _regionId;
			set
			{
				_regionId = value;
				OnPropertyChanged(nameof(RegionId));
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