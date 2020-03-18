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

namespace App1.ViewModels.ProjectSchedule
{
    public class ProjectScheduleTaskViewModel : INotifyPropertyChanged
    {
	    public event PropertyChangedEventHandler PropertyChanged;

	    [NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }
	    private int _projectId;
		private int _projectScheduleTaskId;
	    private DateTime _scheduledStartDate;
		private DateTime _scheduledEndDate;
		private int _taskClassId;
		private string _taskDescription;

		public ProjectScheduleTaskViewModel()
		{
		}
		public ProjectScheduleTaskViewModel(ProjectScheduleTask projectScheduleTask)
		{
			_projectScheduleTaskId = projectScheduleTask.ProjectScheduleTaskId;
			_scheduledEndDate = projectScheduleTask.ScheduledEndDate;
			_scheduledStartDate = projectScheduleTask.ScheduledStartDate;
			_projectId = projectScheduleTask.ProjectId;
			_taskClassId = projectScheduleTask.TaskClassId;
			_taskDescription = projectScheduleTask.TaskClassLink.Description;
		}
		public int ProjectId
		{
			get => _projectId;
			set
			{
				_projectId = value;
				OnPropertyChanged(nameof(ProjectId));
			}
		}
		public int ProjectScheduleTaskId
		{
			get => _projectScheduleTaskId;
			set
			{
				_projectScheduleTaskId = value;
				OnPropertyChanged(nameof(ProjectScheduleTaskId));
			}
		}

		public string TaskDescription
		{
			get => _taskDescription;
			set
			{
				_taskDescription = value;

			}
		}


		public DateTime ScheduledStartDate
		{
			get => _scheduledStartDate;
			set
			{
				_scheduledStartDate = value;
				OnPropertyChanged(nameof(ScheduledEndDate));
			}
		}
		public DateTime ScheduledEndDate
		{
			get => _scheduledEndDate;
			set
			{
				_scheduledEndDate = value;
				OnPropertyChanged(nameof(ScheduledEndDate));
			}
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
    }
}
