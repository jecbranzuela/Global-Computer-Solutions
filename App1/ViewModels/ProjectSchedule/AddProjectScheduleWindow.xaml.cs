using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using App1.Annotations;
using App1.ViewModels.Task;

namespace App1.ViewModels.ProjectSchedule
{
    /// <summary>
    /// Interaction logic for AddProjectScheduleWindow.xaml
    /// </summary>
    public partial class AddProjectScheduleWindow : Window
    {
	    private AddProjectScheduleViewModel _toAddProjectSchedule;
	    private ProjectScheduleTaskListVM _projectScheduleTaskListVm;
        private AddProjectScheduleWindow()
        {
            InitializeComponent();
        }

        public AddProjectScheduleWindow(ProjectScheduleTaskListVM _list) :this()
        {
	        _projectScheduleTaskListVm = _list;
	        DataContext = _toAddProjectSchedule = new AddProjectScheduleViewModel(_list.ReturnContext(), _list);
        }

        private void BtnAddTask_OnClick(object sender, RoutedEventArgs e)
        {
            _toAddProjectSchedule.Add();
            this.Close();
        }
        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
	        this.Close();
        }

        private void BtnAddNewTask_OnClick(object sender, RoutedEventArgs e)
        {
	        var adTask = new AddTaskView(new TaskListViewModel(_projectScheduleTaskListVm.ReturnContext().TaskClassService),
	        _projectScheduleTaskListVm.ReturnContext().TaskClassService);
            adTask.Show();
        }

        private void BtnRefresh_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
