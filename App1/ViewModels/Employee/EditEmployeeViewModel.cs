using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ServiceLayer;

namespace App1.ViewModels.Employee
{
    public class EditEmployeeViewModel
    {
        private EmployeeService _employeeService;
        public EmployeeViewModel AssociatedEmployeeModel { get; private set; }
        public ObservableCollection<Entities.Region> Regions { get; }
        public Entities.Region SelectedRegion { get; set; }

        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfHire { get; set; }

        public EditEmployeeViewModel(EmployeeViewModel employeeModel, 
        EmployeeRegionService employeeRegionService)
        {
            AssociatedEmployeeModel = employeeModel;
            _employeeService = employeeRegionService.EmployeeService;
            Regions = new ObservableCollection<Entities.Region>(
                employeeRegionService.RegionService.GetRegions());

            SelectedRegion = Regions.First(c => c.RegionId == AssociatedEmployeeModel.RegionId);

            CopyEditableFields(employeeModel);
        }

        private void CopyEditableFields(EmployeeViewModel employeeModel)
        {
           LastName = employeeModel.LastName;
            MiddleInitial = employeeModel.MiddleInitial;
            FirstName = employeeModel.FirstName;
            DateOfHire = employeeModel.DateOfHire;
        }

        public void Edit()
        {
            AssociatedEmployeeModel.LastName = LastName;
            AssociatedEmployeeModel.MiddleInitial = MiddleInitial;
            AssociatedEmployeeModel.FirstName = FirstName;
            AssociatedEmployeeModel.DateOfHire = DateOfHire;

            if (SelectedRegion == null)
            {
                _employeeService.EditEmployee(
                AssociatedEmployeeModel.EmployeeId,AssociatedEmployeeModel.RegionId,
                AssociatedEmployeeModel.FirstName,AssociatedEmployeeModel.LastName,
                AssociatedEmployeeModel.MiddleInitial,AssociatedEmployeeModel.DateOfHire
                
                );
            }
            else
            {
                _employeeService.EditEmployee(
                AssociatedEmployeeModel.EmployeeId,SelectedRegion.RegionId,
                AssociatedEmployeeModel.FirstName,AssociatedEmployeeModel.LastName,
                AssociatedEmployeeModel.MiddleInitial,AssociatedEmployeeModel.DateOfHire
                );

                AssociatedEmployeeModel.Region = SelectedRegion.Name;
            }
        }
    }
}
