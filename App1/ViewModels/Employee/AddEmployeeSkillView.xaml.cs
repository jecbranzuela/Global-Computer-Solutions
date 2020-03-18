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

namespace App1.ViewModels.Employee
{
    /// <summary>
    /// Interaction logic for AddEmployeeSkillView.xaml
    /// </summary>
    public partial class AddEmployeeSkillView : Window
    {
	    private EmployeeSkillsListViewModel _empSkill;
	    private AddEmployeeSkillViewModel _toAddEmployeeSkill;
        public AddEmployeeSkillView()
        {
            InitializeComponent();
        }

        public AddEmployeeSkillView(EmployeeSkillsListViewModel empSkill) :this()
        {
	        _empSkill = empSkill;
	        DataContext = _toAddEmployeeSkill = new AddEmployeeSkillViewModel(empSkill.ReturnContext(), empSkill);
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _toAddEmployeeSkill.Add();
            this.Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
