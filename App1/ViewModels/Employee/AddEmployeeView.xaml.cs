using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ServiceLayer;

namespace App1.ViewModels.Employee
{
    /// <summary>
    /// Interaction logic for AddEmployeeView.xaml
    /// </summary>
    public partial class AddEmployeeView : Window
    {
        private AddEmployeeViewModel _toAddEmployee;
        public AddEmployeeView()
        {
            InitializeComponent();
        }

        public AddEmployeeView(EmployeeListViewModel employeeListViewModel,
        EmployeeRegionService employeeRegionService) :this()
        {
            _toAddEmployee = new AddEmployeeViewModel(employeeRegionService.EmployeeService, employeeRegionService.RegionService, employeeListViewModel);

            DataContext = _toAddEmployee;

        }
        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _toAddEmployee.Add();
            MessageBox.Show("Succesfully Added.");
            this.Close();
        }
    }
}
