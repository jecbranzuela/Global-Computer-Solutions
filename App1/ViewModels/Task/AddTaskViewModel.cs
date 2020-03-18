using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCSClasses.EFClasses;
using ServiceLayer;

namespace App1.ViewModels.Task
{
    public class AddTaskViewModel
    {
	    private TaskClassService _taskClassService;
	    private readonly TaskListViewModel _taskListViewModel;
	    public TaskViewModel AddTaskModel { get; private set; }

	    public AddTaskViewModel(TaskClassService taskClassService,
	    TaskListViewModel taskListViewModel)
	    {
		    AddTaskModel = new TaskViewModel();
		    _taskClassService = taskClassService;
		    _taskListViewModel = taskListViewModel;
	    }

	    public void Add()
	    {
			var toAddTask = new TaskClass();
			toAddTask.Description = AddTaskModel.Description;
			_taskClassService.AddTask(toAddTask);
			AddTaskModel.TaskClassId = toAddTask.TaskClassId;
			_taskListViewModel.TaskList.Insert(0,AddTaskModel);
	    }
    }
}
