using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App1.Annotations;
using Entities;
using GCSClasses.EFClasses;
using ServiceLayer;

namespace App1.ViewModels.ProjectSchedule
{
    public class AddProjectScheduleViewModel:INotifyPropertyChanged
    {
	    private ProjCustEmpRegService _projCustEmpRegService;

	    private ProjectScheduleTaskListVM _projectScheduleTaskListVm;
	    public TaskClass SelectedTask { get; set; }

	    //public DateTime ScheduledStartDate { get; set; }
	    //public DateTime ScheduledEndDate { get; set; }
	    private ObservableCollection<TaskClass> _taskList;

	    public ObservableCollection<TaskClass> TaskList
	    {
		    get => _taskList;
		    set
		    {
			    _taskList = value;
				OnPropertyChanged(nameof(TaskList));
				
		    }
	    }
	    public ProjectScheduleTaskViewModel AddProjectScheduleTask { get; set; }

	    public AddProjectScheduleViewModel(ProjCustEmpRegService projCustEmpRegService,
	    ProjectScheduleTaskListVM projectScheduleTaskList)
	    {
		    AddProjectScheduleTask = new ProjectScheduleTaskViewModel();
		    _projCustEmpRegService = projCustEmpRegService;
		    _projectScheduleTaskListVm = projectScheduleTaskList;
			TaskList = new ObservableCollection<TaskClass>(_projCustEmpRegService
			.TaskClassService.GetTasks()
			);
			SelectedTask = TaskList.First();
	    }

	    public void Add()
	    {
			var toAddProjSched = new ProjectScheduleTask();
			toAddProjSched.ProjectId = _projectScheduleTaskListVm.ProjectId;
			toAddProjSched.ScheduledEndDate = AddProjectScheduleTask.ScheduledEndDate;
			toAddProjSched.ScheduledStartDate = AddProjectScheduleTask.ScheduledStartDate;
			toAddProjSched.TaskClassId = SelectedTask.TaskClassId;
			_projCustEmpRegService.ProjectScheduleTaskService.AddProjectTask(toAddProjSched);
			_projectScheduleTaskListVm.ProjectScheduleTaskList.Insert(0,AddProjectScheduleTask);
			AddProjectScheduleTask.ProjectScheduleTaskId = toAddProjSched.ProjectScheduleTaskId;
			AddProjectScheduleTask.TaskDescription = SelectedTask.Description;
			AddProjectScheduleTask.ProjectId = toAddProjSched.ProjectId;
			AddProjectScheduleTask.TaskClassId = SelectedTask.TaskClassId;
		}

	    public event PropertyChangedEventHandler PropertyChanged;

	    [NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }
    }
}
