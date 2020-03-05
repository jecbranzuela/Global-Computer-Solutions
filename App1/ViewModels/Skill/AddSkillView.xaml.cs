using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ServiceLayer;

namespace App1.ViewModels.Skill
{
    /// <summary>
    /// Interaction logic for AddSkillView.xaml
    /// </summary>
    public partial class AddSkillView : Window
    {
        private AddSkillViewModel _toAddSkill;
        public AddSkillView()
        {
            InitializeComponent();
        }

        public AddSkillView(SkillListViewModel skillListViewModel,
            SkillService skillService) : this()
        {
            _toAddSkill = new AddSkillViewModel(skillService, skillListViewModel);

            DataContext = _toAddSkill;
        }
        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _toAddSkill.Add();
            this.Close();
        }
    }
}
