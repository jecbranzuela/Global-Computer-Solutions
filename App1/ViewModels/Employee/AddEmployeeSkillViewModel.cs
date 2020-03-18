using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using App1.Annotations;
using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

namespace App1.ViewModels.Employee
{
	public class AddEmployeeSkillViewModel :INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private EmployeeRegionService _employeeRegionService;
		private EmployeeSkillsListViewModel _employeeSkillsListViewModel;
		public Entities.Skill SelectedSkill { get; set; }
		public ObservableCollection<Entities.Skill> SkillList { get; set; }
		public EmployeeSkillViewModel AddEmployeeSkillModel { get; set; }
		public AddEmployeeSkillViewModel(EmployeeRegionService empRegionService, EmployeeSkillsListViewModel empSkill)
		{
			AddEmployeeSkillModel = new EmployeeSkillViewModel();
			_employeeRegionService = empRegionService;
			_employeeSkillsListViewModel = empSkill;
			SkillList = new ObservableCollection<Entities.Skill>(
			_employeeRegionService.SkillService.GetSkills()
			);

			SelectedSkill = SkillList.First();
		}

		public void Add()
		{
			var toAddEmpSkill = new EmployeeSkill();
			toAddEmpSkill.EmployeeId = _employeeSkillsListViewModel.EmployeeId;
			toAddEmpSkill.SkillId = SelectedSkill.SkillId;
			_employeeRegionService.EmployeeSkillService.AddEmployeeSkill(toAddEmpSkill);
			_employeeSkillsListViewModel.EmployeeSkillList.Insert(0,AddEmployeeSkillModel);
			AddEmployeeSkillModel.SkillDescription = SelectedSkill.Description;
			AddEmployeeSkillModel.EmployeeSkillId = toAddEmpSkill.EmployeeSkillId;
			AddEmployeeSkillModel.EmployeeId = toAddEmpSkill.EmployeeId;
		}
	}
}