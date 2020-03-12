using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App1.Annotations;

namespace App1.ViewModels.Customer
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private int _customerId;
        private string _lastName;
        private string _middleInitial;
        private string _firstName;
        private int _phoneNumber;
        private string _region;
        private int _regionId;
        public string FullName { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public CustomerViewModel(string lastName, string middleInitial, string firstName, int phoneNumber, string region, int regionId)
        //{
        //    _lastName = lastName;
        //    _middleInitial = middleInitial;
        //    _firstName = firstName;
        //    _phoneNumber = phoneNumber;
        //    _region = region;
        //    _regionId = regionId;
        //    FullName = $"{_lastName},  {_firstName}";
        //}

        public CustomerViewModel(Entities.Customer customer)
        {
	        CustomerId = customer.CustomerId;
	        LastName = customer.LastName;
	        MiddleInitial = customer.MiddleInitial;
	        FirstName = customer.FirstName;
	        PhoneNumber = customer.PhoneNumber;
	        Region = customer.RegionLink.Name;
	        RegionId = customer.RegionId;
	        FullName = $"{_lastName},  {_firstName}";


        }

        public CustomerViewModel()
        {
            
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

        public int PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
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
