using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ServiceLayer;

namespace App1.ViewModels.Customer
{
    public class AddCustomerViewModel
    {
        private CustomerService _customerService;
        private RegionService _regionService;
        private readonly CustomerListViewModel _customerListViewModel;

        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        
        public int PhoneNumber { get; set; }
        public Entities.Region SelectedRegion { get; set; }
        public ObservableCollection<Entities.Region> Regions { get; }
        public CustomerViewModel AddCustomerModel { get; private set; }

        public AddCustomerViewModel(CustomerService customerService, 
            RegionService regionService,
            CustomerListViewModel customerListViewModel)
        {
            AddCustomerModel = new CustomerViewModel();
            _customerService = customerService;
            _regionService = regionService;
            _customerListViewModel = customerListViewModel;

            Regions = new ObservableCollection<Entities.Region>(_regionService.GetRegions());

            SelectedRegion = Regions.First();
        }
        public void Add()
        {
            var toAddCustomer = new Entities.Customer();
            toAddCustomer.FirstName = AddCustomerModel.FirstName;
            toAddCustomer.MiddleInitial = AddCustomerModel.MiddleInitial;
            toAddCustomer.LastName = AddCustomerModel.LastName;
            toAddCustomer.PhoneNumber = AddCustomerModel.PhoneNumber;
            toAddCustomer.RegionId = SelectedRegion.RegionId;
            _customerService.AddCustomer(toAddCustomer);
            _customerListViewModel.CustomerList.Insert(0,AddCustomerModel);
            AddCustomerModel.CustomerId = toAddCustomer.CustomerId;
            AddCustomerModel.Region = SelectedRegion.Name;
        }
    }
}
