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
        private CustomerService _customerService;
        private string _searchText;

        public ObservableCollection<CustomerViewModel> CustomerList { get; set; }
        public CustomerViewModel SelectedCustomer { get; set; }

        public CustomerListViewModel(CustomerService customerService)
        {
            _customerService = customerService;
            CustomerList = new ObservableCollection<CustomerViewModel>(
                _customerService.GetCustomers()
                    .Select(c=> new CustomerViewModel(
                        c.LastName,c.MiddleInitial,c.FirstName,c.PhoneNumber,c.RegionLink.Name,c.RegionId))
                
                );
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
            var customers = _customerService.GetCustomers()
                .Where(c => c.FirstName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));

            foreach (var customer in customers)
            {
                var customerModel = new CustomerViewModel(customer.LastName,customer.MiddleInitial,
                    customer.FirstName,customer.PhoneNumber,customer.RegionLink.Name,customer.RegionId);
                CustomerList.Add(customerModel);
            }
        }

    }
}
