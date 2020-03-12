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

namespace App1.ViewModels.Skill
{
    /// <summary>
    /// Interaction logic for EditSkillView.xaml
    /// </summary>
    public partial class EditSkillView : Window
    {
	    private EditSkillViewModel _toEditSKill;
        private EditSkillView()
        {
            InitializeComponent();
        }

        public EditSkillView(EditSkillViewModel skillToEdit):this()
        {
	        DataContext = _toEditSKill = skillToEdit;
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            _toEditSKill.Edit();
            this.Close();
        }
    }
}
