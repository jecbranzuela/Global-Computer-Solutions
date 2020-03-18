using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App1.Annotations;
using GCSClasses.EFClasses;

namespace App1.ViewModels.Task
{
    public class TaskViewModel : INotifyPropertyChanged
    {
	    private int _taskClassId;
	    private string _description;

	    public event PropertyChangedEventHandler PropertyChanged;

	    [NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }

	    public TaskViewModel(TaskClass task)
	    {
		    _taskClassId = task.TaskClassId;
		    _description = task.Description;
	    }

	    public TaskViewModel()
	    {
		    
	    }

	    public int TaskClassId
	    {
		    get => _taskClassId;
		    set
		    {
			    _taskClassId = value;
				OnPropertyChanged(nameof(TaskClassId));
		    }
	    }

	    public string Description
	    {
		    get => _description;
		    set
		    {
			    _description = value;
				OnPropertyChanged(nameof(Description));
		    }
	    }
    }
}
