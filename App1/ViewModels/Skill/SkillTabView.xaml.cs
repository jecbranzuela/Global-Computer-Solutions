﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App1.ViewModels.Skill
{
    /// <summary>
    /// Interaction logic for SkillTabView.xaml
    /// </summary>
    public partial class SkillTabView : UserControl
    {
        public SkillTabView()
        {
            InitializeComponent();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var skillListContext = (SkillListViewModel)DataContext;
            var edSkill = new EditSkillView(skillListContext.EditSkillViewModel());
            edSkill.Show();
        }
    }
}
