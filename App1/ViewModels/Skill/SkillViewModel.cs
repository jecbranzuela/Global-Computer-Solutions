﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App1.Annotations;

namespace App1.ViewModels.Skill
{
    public class SkillViewModel:INotifyPropertyChanged
    {
        private int _skillId;
        private string _description;
        private int _rateOfPay;


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SkillViewModel()
        {
            
        }

        public SkillViewModel(Entities.Skill skill)
        {
	        SkillId = skill.SkillId;
	        Description = skill.Description;
	        RateOfPay = skill.RateOfPay;

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

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                    OnPropertyChanged(nameof(Description));
            }
        }

        public int RateOfPay
        {
            get => _rateOfPay;
            set
            {
                _rateOfPay = value;
                OnPropertyChanged(nameof(RateOfPay));
            }
        }

    }
}
