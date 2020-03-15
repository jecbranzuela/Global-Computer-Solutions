using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using App1.ViewModels.Project;
using ServiceLayer;

namespace App1.ViewModels.Employee
{
    /// <summary>
    /// Interaction logic for AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {
	    private AddProjectViewModel _toAddProject;
        private AddProjectWindow()
        {
            InitializeComponent();
        }

        public AddProjectWindow(ProjectListViewModel projectListViewModel, ProjCustEmpRegService projCustEmpRegService) :this()
        {
            _toAddProject = new AddProjectViewModel(projectListViewModel,projCustEmpRegService);
            DataContext = _toAddProject;
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
	        this.Close();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _toAddProject.Add();
            this.Close();
        }
    }
}
