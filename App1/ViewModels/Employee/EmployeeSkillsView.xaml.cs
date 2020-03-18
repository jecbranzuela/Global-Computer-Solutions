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
    /// Interaction logic for EmployeeSkillsView.xaml
    /// </summary>
    public partial class EmployeeSkillsView : Window
    {
	    private EmployeeSkillsListViewModel _empSkill;
	    private EmployeeSkillsView()
        {
            InitializeComponent();
        }

	    public EmployeeSkillsView(EmployeeSkillsListViewModel employeeSkillsList) :this()
	    {
		    DataContext = _empSkill = employeeSkillsList;

	    }

	    private void BtnAddSkill_OnClick(object sender, RoutedEventArgs e)
	    {
            var addSkill = new AddEmployeeSkillView(_empSkill);
            addSkill.Show();
	    }

	    private void Btnback_OnClick(object sender, RoutedEventArgs e)
	    {
			this.Close();
	    }
    }
}
