using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace App1.ViewModels.Skill
{
    public class EditSkillViewModel
    {
	    private SkillService _skillService;
        public SkillViewModel AssociatedSkillModel { get; private set; }
        public string Description { get; set; }
        public int RateOfPay { get; set; }

        public EditSkillViewModel(SkillService skillService, SkillViewModel skillModel)
        {
	        _skillService = skillService;
	        AssociatedSkillModel = skillModel;
	        CopyEditableFields(skillModel);
        }

        private void CopyEditableFields(SkillViewModel skillModel)
        {
	        Description = skillModel.Description;
	        RateOfPay = skillModel.RateOfPay;
        }

        public void Edit()
        {
	        AssociatedSkillModel.Description = Description;
	        AssociatedSkillModel.RateOfPay = RateOfPay;

            _skillService.EditSkill(AssociatedSkillModel.SkillId,
            AssociatedSkillModel.Description,
            AssociatedSkillModel.RateOfPay
            );
        }
    }
}
