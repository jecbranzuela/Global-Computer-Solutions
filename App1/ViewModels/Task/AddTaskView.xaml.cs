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
using App1.ViewModels.ProjectSchedule;
using ServiceLayer;

namespace App1.ViewModels.Task
{
    /// <summary>
    /// Interaction logic for AddTaskView.xaml
    /// </summary>
    public partial class AddTaskView : Window
    {
	    private AddTaskViewModel _toAddTask;
	    private AddTaskView()
        {
            InitializeComponent();
        }

	    public AddTaskView(TaskListViewModel taskListViewModel,
	    TaskClassService taskClassService):this()
	    {
		    DataContext = _toAddTask = new AddTaskViewModel(taskClassService, taskListViewModel);
	    }
        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _toAddTask.Add();
            this.Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
