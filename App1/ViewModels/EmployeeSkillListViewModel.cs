using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ServiceLayer;

namespace App1.ViewModels
{
    public class EmployeeSkillListViewModel
    {
        private EmployeeSkillService _employeeSkillService;
        public ObservableCollection<Entities.EmployeeSkill> EmployeeSkillList { get; set; }
        public Entities.EmployeeSkill SelectedEmployeeSkill { get; set; }

        public EmployeeSkillListViewModel(EmployeeSkillService employeeSkillService)
        {
            _employeeSkillService = employeeSkillService;
            EmployeeSkillList = new ObservableCollection<Entities.EmployeeSkill>(
            _employeeSkillService.GetEmployeeSkills()
            );

        }
    }
}
