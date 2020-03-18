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
    public class AddEmployeeViewModel
    {
        private EmployeeService _employeeService;
        private RegionService _regionService;
        private readonly EmployeeListViewModel _employeeListViewModel;
        //public string FirstName { get; set; }
        //public string MiddleInitial { get; set; }
        //public string LastName { get; set; }
        //public DateTime DateOfHire { get; set; }
        public Entities.Region SelectedRegion { get; set; }
        public ObservableCollection<Entities.Region> Regions { get; }

        public EmployeeViewModel AddEmployeeModel { get; private set; }

        public AddEmployeeViewModel(EmployeeService employeeService, RegionService regionService, EmployeeListViewModel employeeListViewModel)
        {
            AddEmployeeModel = new EmployeeViewModel();
            _employeeService = employeeService;
            _regionService = regionService;
            _employeeListViewModel = employeeListViewModel;
           // DateOfHire = DateTime.Now;
            Regions = new ObservableCollection<Entities.Region>(_regionService.GetRegions());

            SelectedRegion = Regions.First();
        }

        public void Add()
        {
            var toAddEmployee = new Entities.Employee();
            toAddEmployee.FirstName = AddEmployeeModel.FirstName;
            toAddEmployee.MiddleInitial = AddEmployeeModel.MiddleInitial;
            toAddEmployee.LastName = AddEmployeeModel.LastName;
            toAddEmployee.DateOfHire = AddEmployeeModel.DateOfHire;
            toAddEmployee.RegionId = SelectedRegion.RegionId;
            _employeeService.AddEmployee(toAddEmployee);
            _employeeListViewModel.EmployeeList.Insert(0,AddEmployeeModel);
            AddEmployeeModel.RegionId = SelectedRegion.RegionId;
            AddEmployeeModel.EmployeeId = toAddEmployee.EmployeeId;
            AddEmployeeModel.Region = SelectedRegion.Name;

        }
    }
}
