using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App1.Annotations;
using GCSClasses.EFClasses;

namespace App1.ViewModels.Task
{
    public class AddTaskToProjectViewModel : INotifyPropertyChanged
    {
	    public event PropertyChangedEventHandler PropertyChanged;

	    [NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }

	    public ObservableCollection<TaskViewModel> TaskList { get; set; }
	    private TaskViewModel _selectedTask;

	    //public TaskViewModel SelectedTask
	    //{
	    //}
    }
}
