using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App1.Annotations;
using Entities;

namespace App1.ViewModels.Employee
{
    public class EmployeeSkillViewModel : INotifyPropertyChanged
    {
	    public event PropertyChangedEventHandler PropertyChanged;

	    [NotifyPropertyChangedInvocator]
	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }

	    private int _employeeSkillId;
	    private int _employeeId;
	    private int _skillId;
	    private string _employeeName;
	    private string _skillDescription;

	    public EmployeeSkillViewModel()
	    {
		    
	    }
	    public EmployeeSkillViewModel(EmployeeSkill empSkill)
	    {
		    EmployeeId = empSkill.EmployeeId;
		    EmployeeSkillId = empSkill.EmployeeSkillId;
		    SkillId = empSkill.SkillId;
			EmployeeName = new EmployeeViewModel(empSkill.EmployeeLink).FullName;
			SkillDescription = empSkill.SkillLink.Description;

	    }
	    public int EmployeeSkillId
	    {
		    get => _employeeSkillId;
		    set
		    {
			    _employeeSkillId = value;
				OnPropertyChanged(nameof(EmployeeSkillId));
		    }
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

	    public int SkillId
	    {
		    get => _skillId;
		    set
		    {
			    _skillId = value;
				OnPropertyChanged(nameof(SkillId));
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

	    public string SkillDescription
	    {
		    get => _skillDescription;
		    set
		    {
			    _skillDescription = value;
				OnPropertyChanged(nameof(SkillDescription));
		    }
	    }

    }
}
