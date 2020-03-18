using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using App1.Annotations;
using ServiceLayer;

namespace App1.ViewModels.Task
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
	    private TaskClassService _taskClassService;
	    private ObservableCollection<TaskViewModel> _taskList;

	    public ObservableCollection<TaskViewModel> TaskList
	    {
		    get => _taskList;
		    set
		    {
			    _taskList = value;
                OnPropertyChanged(nameof(TaskList));
		    }
	    }
        private TaskViewModel _selectedTask;

        public TaskViewModel SelectedTask
        {
	        get => _selectedTask;
	        set { _selectedTask = value; }
        }

        public TaskListViewModel(TaskClassService taskClassService)
        {
	        _taskClassService = taskClassService;
            _taskList = new ObservableCollection<TaskViewModel>(
            _taskClassService.GetTasks()
            .Select(c=> new TaskViewModel(c))
            );
        }

        public TaskClassService ReturnTaskClassContext()
        {
	        return _taskClassService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
	        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
