using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App1.Annotations;
using App1.ViewModels.Employee;

namespace App1.ViewModels.Assignment
{
    public class AssignmentViewModel : INotifyPropertyChanged
    {
	    public event PropertyChangedEventHandler PropertyChanged;

	    [NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }

	    private int _assignmentId;
	    private DateTime _startDate;
	    private DateTime _endDate;
	    private int _employeeId;
	    private string _employeeName;
	    private int _projectScheduleTaskId;
	    private int _skillId;

	    public AssignmentViewModel(Entities.Assignment assignment)
	    {
		    _assignmentId = assignment.AssignmentId;
		    _startDate = assignment.StartDate;
		    _endDate = assignment.EndDate;
		    _employeeId = assignment.EmployeeId;
			EmployeeName = new EmployeeViewModel(assignment.EmployeeLink).FullName;
		    _projectScheduleTaskId = assignment.ProjectScheduleTaskId;
	    }
	    public int EmployeeId
	    {
		    get => _employeeId;
		    set
		    {
			    _employeeId = value;
			    OnPropertyChanged(nameof(EmployeeId));
		    }
	    }
		public string EmployeeName
	    {
		    get => _employeeName;
		    set
		    {
			    _employeeName = value;
			    OnPropertyChanged(nameof(EmployeeName));
		    }
	    }
	    public DateTime StartDate
	    {
		    get => _startDate;
		    set
		    {
			    _startDate = value;
			    OnPropertyChanged(nameof(StartDate));
		    }
	    }
	    public DateTime EndDate
	    {
		    get => _endDate;
		    set
		    {
			    _endDate = value;
			    OnPropertyChanged(nameof(EndDate));
		    }
	    }
		public int AssignmentId
	    {
		    get => _assignmentId;
		    set
		    {
			    _assignmentId = value;
				OnPropertyChanged(nameof(AssignmentId));
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

	    
    }
}
