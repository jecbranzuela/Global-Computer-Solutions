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
using App1.ViewModels.ProjectSchedule;
using ServiceLayer;

namespace App1.ViewModels.Project
{
    /// <summary>
    /// Interaction logic for ProjectTabView.xaml
    /// </summary>
    public partial class ProjectTabView : UserControl
    {
        public ProjectTabView()
        {
            InitializeComponent();
        }

        private void BtnShowProjectSchedulesList_OnClick(object sender, RoutedEventArgs e)
        {
	        var context = (ProjectListViewModel) DataContext;
	       // var context1 = (ProjCustEmpRegService) DataContext;
	        var showSched = new ProjectScheduleTab(/*context1,*/context.ProjectScheduleTaskList());
            showSched.Show();
        }

        private void BtnShowBills_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
	        var context = (ProjectListViewModel)DataContext;

            var editProjWin = new EditProjectWindow(context.CreateEditProjectViewModel());
            editProjWin.Show();
        }
    }
}
