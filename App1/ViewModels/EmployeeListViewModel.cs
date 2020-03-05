using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace App1.ViewModels
{
    public class EmployeeListViewModel
    {
        private EmployeeService _employeeService;
        private string _searchText;

        public ObservableCollection<EmployeeViewModel> EmployeeList { get; }
        public EmployeeViewModel SelectedEmployee { get; set; }

        public EmployeeListViewModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
            EmployeeList = new ObservableCollection<EmployeeViewModel>(
                _employeeService.GetEmployees()
                .Select(c => new EmployeeViewModel(
                    c.LastName, c.MiddleInitial, c.FirstName,
                    c.DateOfHire, c.RegionLink.Name, c.RegionId))
            );
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchEmployee(_searchText);
            }
        }

        private void SearchEmployee(string searchString)
        {
            EmployeeList.Clear();

            var employees = _employeeService.GetEmployees()
                .Where(c => c.FirstName.Contains(searchString,StringComparison.InvariantCultureIgnoreCase));
                //.Where(c => c.FirstName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)
                            //|| c.LastName.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)
                            //|| c.MiddleInitial.Contains(searchString, StringComparison.InvariantCultureIgnoreCase)
                //);

            foreach (var employee in employees)
            {
                var employeeModel = new EmployeeViewModel(
                    employee.LastName,
                    employee.MiddleInitial,
                    employee.FirstName,
                    employee.DateOfHire,
                    employee.RegionLink.Name,
                    employee.RegionId
                    );
                EmployeeList.Add(employeeModel);
            }
        }
    }
}
