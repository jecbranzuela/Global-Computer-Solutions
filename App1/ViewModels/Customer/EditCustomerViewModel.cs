using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace App1.ViewModels.Customer
{
    public class EditCustomerViewModel
    {
	    private CustomerService _customerService;
	    public CustomerViewModel AssociatedCustomerModel { get; private set; }

	    public ObservableCollection<Entities.Region> Regions { get; }
	    public Entities.Region SelectedRegion { get; set; }

	    public string LastName { get; set; }
	    public string MiddleInitial { get; set; }
	    public string FirstName { get; set; }
	    public int PhoneNumber { get; set; }
	    public string Region { get; set; }

	    public EditCustomerViewModel(CustomerViewModel customerModel,
	    CustomerRegionService customerRegionService)
	    {
		    AssociatedCustomerModel = customerModel;
		    _customerService = customerRegionService.CustomerService;
		    Regions = new ObservableCollection<Entities.Region>(
		    customerRegionService.RegionService.GetRegions());

		    SelectedRegion = Regions.First(c => c.RegionId == AssociatedCustomerModel.RegionId);
		    CopyEditableFields(customerModel);
	    }

	    private void CopyEditableFields(CustomerViewModel customerModel)
	    {
		    LastName = customerModel.LastName;
		    MiddleInitial = customerModel.MiddleInitial;
		    FirstName = customerModel.FirstName;
		    PhoneNumber = customerModel.PhoneNumber;
		    Region = customerModel.Region;
	    }

	    public void Edit()
	    {
		    AssociatedCustomerModel.LastName = LastName;
		    AssociatedCustomerModel.MiddleInitial = MiddleInitial;
		    AssociatedCustomerModel.FirstName = FirstName;
		    AssociatedCustomerModel.PhoneNumber = PhoneNumber;

		    if (SelectedRegion == null)
		    {
				_customerService.EditCustomer(
				AssociatedCustomerModel.CustomerId,AssociatedCustomerModel.RegionId,
				AssociatedCustomerModel.FirstName,AssociatedCustomerModel.MiddleInitial,
				AssociatedCustomerModel.LastName,AssociatedCustomerModel.PhoneNumber
				);
		    }
		    else
		    {
				_customerService.EditCustomer(
				AssociatedCustomerModel.CustomerId, AssociatedCustomerModel.RegionId,
				AssociatedCustomerModel.FirstName, AssociatedCustomerModel.MiddleInitial,
				AssociatedCustomerModel.LastName, AssociatedCustomerModel.PhoneNumber
				);

				AssociatedCustomerModel.Region = SelectedRegion.Name;
		    }
	    }
    }
}
