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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App1.ViewModels.Employee
{
    /// <summary>
    /// Interaction logic for EmployeeTabView.xaml
    /// </summary>
    public partial class EmployeeTabView : UserControl
    {
        public EmployeeTabView()
        {
            InitializeComponent();
        }

        private void BtnEditEmployee_OnClick(object sender, RoutedEventArgs e)
        {
	        var employeeListContext = (EmployeeListViewModel)DataContext;
            


	        var edEmp = new EditEmployeeView(employeeListContext.CreateEditEmployeeViewModel());
            edEmp.Show();
        }

        private void BtnShowEmpSkill_OnClick(object sender, RoutedEventArgs e)
        {
	        var employeeListContext = (EmployeeListViewModel)DataContext;
            var emps = new EmployeeSkillsView(employeeListContext.EmpSkill());
            emps.Show();
        }
    }
}
