using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace App1.ViewModels.Skill
{
    public class AddSkillViewModel
    {
        private SkillService _skillService;
        private readonly SkillListViewModel _skillListViewModel;
        
        public string Description { get; set; }
        public int RateOfPay { get; set; }
        public SkillViewModel AddSkillModel { get; private set; }

        public AddSkillViewModel(SkillService skillService,
            SkillListViewModel skillListViewModel)
        {
            AddSkillModel = new SkillViewModel();
            _skillService = skillService;
            _skillListViewModel = skillListViewModel;
        }

        public void Add()
        {
            var toAddSkill = new Entities.Skill();
            toAddSkill.Description = AddSkillModel.Description;
            toAddSkill.RateOfPay = AddSkillModel.RateOfPay;
            _skillService.AddSkill(toAddSkill);
            _skillListViewModel.SkillList.Insert(0,AddSkillModel);
            AddSkillModel.SkillId = toAddSkill.SkillId;
        }
    }
}
