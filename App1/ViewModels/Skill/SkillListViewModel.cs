using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels.Employee;
using App1.ViewModels.Skill;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;

namespace App1.ViewModels
{
    public class SkillListViewModel
    {
        private SkillService _skillService;
        private string _searchText;
        private SkillViewModel _selectedSkill;

        public ObservableCollection<SkillViewModel> SkillList { get;}

        public ObservableCollection<EmployeeViewModel> EmployeesWithSameSkill { get; }

      public SkillViewModel SelectedSkill
      {
          get => _selectedSkill;
          set
          {
              _selectedSkill = value;
              LoadEmployeeWithSelectedSkill();

          }
      }
      public SkillListViewModel(SkillService skillService)
      {
          EmployeesWithSameSkill = new ObservableCollection<EmployeeViewModel>();
          _skillService = skillService;
          SkillList = new ObservableCollection<SkillViewModel>(
              _skillService.GetSkills()
                  .Select(c => new SkillViewModel(c.SkillId,
                      c.Description, c.RateOfPay))
          );
      }
        private void LoadEmployeeWithSelectedSkill()
		{
          var employees = _skillService.GetEmployees(SelectedSkill.SkillId)
              .OrderBy(c=>c.LastName);
          EmployeesWithSameSkill.Clear();
          foreach (var employee in employees)
          {
	          EmployeesWithSameSkill.Add(new EmployeeViewModel(employee));
          }

		}

        public EditSkillViewModel EditSkillViewModel()
        {
            return new EditSkillViewModel(_skillService,_selectedSkill);
        }



        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchSkill(_searchText);
            }
        }

        private void SearchSkill(string searchString)
        {
            SkillList.Clear();
            var skills = _skillService.GetSkills()
                .Where(c => c.Description.Contains(searchString, StringComparison.InvariantCultureIgnoreCase));

            foreach (var skill in skills)
            {
                var skillModel = new SkillViewModel(skill.SkillId,skill.Description,skill.RateOfPay);
                SkillList.Add(skillModel);
            }
        }

    }
}
