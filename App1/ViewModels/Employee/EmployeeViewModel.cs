using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App1.Annotations;

namespace App1.ViewModels
{
    public class EmployeeViewModel :INotifyPropertyChanged
    {
        private int _employeeId;
        private string _lastName;
        private string _middleInitial;
        private string _firstName;
        private DateTime _dateOfHire;
        private string _region;
        private int _regionId;

        public EmployeeViewModel(string lastName, string middleInitial, string firstName, DateTime dateOfHire, string region, int regionId)
        {
            LastName = lastName;
            MiddleInitial = middleInitial;
            FirstName = firstName;
            DateOfHire = dateOfHire;
            Region = region;
            RegionId = regionId;
        }
        public EmployeeViewModel()
        {
            
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
    }
}
