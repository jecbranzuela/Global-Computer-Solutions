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
        private RegionService _regionService;
        public EmployeeViewModel AssociatedEmployeeModel { get; private set; }
        public ObservableCollection<Entities.Region> Regions { get; }
        public Entities.Region SelecteRegion { get; set; }

        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfHire { get; set; }
        public string Region { get; set; }

        public EditEmployeeViewModel(EmployeeViewModel employeeModel,
            EmployeeService employeeService, RegionService regionService)
        {
            AssociatedEmployeeModel = employeeModel;
            _employeeService = employeeService;
            _regionService = regionService;
            Regions = new ObservableCollection<Entities.Region>(
                _regionService.GetRegions());

            SelecteRegion = Regions.First(c => c.RegionId == AssociatedEmployeeModel.RegionId);

            CopyEditableFields(employeeModel);
        }

        private void CopyEditableFields(EmployeeViewModel employeeModel)
        {
            LastName = employeeModel.LastName;
            MiddleInitial = employeeModel.MiddleInitial;
            FirstName = employeeModel.FirstName;
            DateOfHire = employeeModel.DateOfHire;
        }

        //public void Edit()
        //{
        //    AssociatedEmployeeModel.LastName = LastName;
        //    AssociatedEmployeeModel.MiddleInitial = MiddleInitial;
        //    AssociatedEmployeeModel.FirstName = FirstName;
        //    AssociatedEmployeeModel.DateOfHire = DateOfHire;

        //    if (SelecteRegion == null)
        //    {
        //        _employeeService.EditEmployee();
        //    }
        //}
    }
}
