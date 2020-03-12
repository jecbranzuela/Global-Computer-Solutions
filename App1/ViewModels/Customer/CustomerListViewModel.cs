using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels.Customer;
using ServiceLayer;

namespace App1.ViewModels
{
    public class CustomerListViewModel
    {
        private CustomerRegionService _customerRegionService;
        private string _searchText;
        private CustomerViewModel _selectedCustomer;
        public ObservableCollection<CustomerViewModel> CustomerList { get; set; }

        public EditCustomerViewModel CreateEditCustomerViewModel()
        {
            return new EditCustomerViewModel(_selectedCustomer,_customerRegionService);
        }
        public CustomerListViewModel(CustomerRegionService customerRegionService)
        {
            _customerRegionService = customerRegionService;
            CustomerList = new ObservableCollection<CustomerViewModel>(
                _customerRegionService.CustomerService.GetCustomers()
                    .Select(c=> new CustomerViewModel(c)));
        }
        public CustomerViewModel SelectedCustomer
        {
	        get => _selectedCustomer;
	        set => _selectedCustomer = value;
        }
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchCustomer(_searchText);
            }
        }

        private void SearchCustomer(string searchString)
        {
            CustomerList.Clear();
            var customers = _customerRegionService.CustomerService.GetCustomers()
                .Where(c => c.FirstName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));

            foreach (var customer in customers)
            {
                var customerModel = new CustomerViewModel(customer);
                CustomerList.Add(customerModel);
            }
        }

    }
}
