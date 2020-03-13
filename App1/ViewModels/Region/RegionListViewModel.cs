using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels.Customer;
using App1.ViewModels.Employee;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

namespace App1.ViewModels.Region
{
    public class RegionListViewModel
    {
        private RegionService _regionService;
        private RegionViewModel _selectedRegion;
        public ObservableCollection<RegionViewModel> RegionList { get; }

        public ObservableCollection<EmployeeViewModel> EmployeesWithSameRegion { get; }
        public ObservableCollection<CustomerViewModel> CustomersWithSameRegion { get; }

        public RegionViewModel SelectedRegion
        {
            get => _selectedRegion;
            set
            {
                _selectedRegion = value;
                LoadEmployeesWithSameRegion();
                LoadCustomersWithSameRegion();
            }
        }


        public RegionListViewModel(RegionService regionService)
        {
            EmployeesWithSameRegion = new ObservableCollection<EmployeeViewModel>();
            CustomersWithSameRegion = new ObservableCollection<CustomerViewModel>();
            _regionService = regionService;
            RegionList = new ObservableCollection<RegionViewModel>(
                _regionService.GetRegions()
                    .Select(c=> new RegionViewModel(
                        c.RegionId,c.Name))
                );
        }

        private void LoadCustomersWithSameRegion()
        {
            var groupBy = _regionService.GetCustomers(SelectedRegion.RegionId)
                .ToList()
                .OrderBy(c => c.LastName);
            CustomersWithSameRegion.Clear();

            foreach (var customer in groupBy)
            {
                CustomersWithSameRegion.Add(new CustomerViewModel(customer));
            }
        }

        private void LoadEmployeesWithSameRegion()
        {
            var groupBy = _regionService.GetEmployees(SelectedRegion.RegionId)
                .ToList()
                .OrderBy(c => c.LastName);
            EmployeesWithSameRegion.Clear();
            foreach (var employee in groupBy)
            {
	            EmployeesWithSameRegion.Add(new EmployeeViewModel(employee));
            }
        }

        //private void LoadEmployeeWithSelectedSkill()
        //{
        //    var employees = _skillService.GetEmployees(SelectedSkill.SkillId);
        //    EmployeesWithSameSkill.Clear();
        //    foreach (var employee in employees)
        //    {
        //        EmployeesWithSameSkill.Add(new EmployeeViewModel(
        //            employee.LastName,
        //            employee.MiddleInitial,
        //            employee.FirstName,
        //            employee.DateOfHire,
        //            employee.RegionLink.Name,
        //            employee.RegionId
        //        ));
        //    }

        //}
    }
}
