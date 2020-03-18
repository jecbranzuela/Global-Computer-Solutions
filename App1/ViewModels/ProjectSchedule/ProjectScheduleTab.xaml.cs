using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using App1.ViewModels.Task;
using ServiceLayer;

namespace App1.ViewModels.ProjectSchedule
{
    /// <summary>
    /// Interaction logic for ProjectScheduleTab.xaml
    /// </summary>
    public partial class ProjectScheduleTab : Window
    {
	    private ProjectScheduleTaskListVM _pstlvm;
        public ProjectScheduleTab()
        {
            InitializeComponent();
        }

        public ProjectScheduleTab(ProjectScheduleTaskListVM project) :this()
        {
	        DataContext = _pstlvm = project;
        }

        private void BtnAddSchedule_OnClick(object sender, RoutedEventArgs e)
        {
            var addSched = new AddProjectScheduleWindow(_pstlvm);
            addSched.Show();
            //var addTask = new AddTaskToProjectView(new TaskListViewModel(_pstlvm.ReturnContext().TaskClassService));
            //addTask.Show();
            //var addTask = new AddTaskView(new TaskListViewModel(_pstlvm.ReturnContext().TaskClassService),
            //_pstlvm.ReturnContext().TaskClassService);
            //addTask.Show();
        }
    }
}
