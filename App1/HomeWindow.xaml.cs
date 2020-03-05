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
using App1.UserControls;
using App1.ViewModels;
using App1.ViewModels.Employee;
using App1.ViewModels.Project;
using App1.ViewModels.Skill;
using GCSClasses;
using ServiceLayer;
using AddCustomerView = App1.ViewModels.Customer.AddCustomerView;

namespace App1
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        #region employee

        private EmployeeListViewModel _employeeListViewModel;
        private EmployeeService _employeeService;

        #endregion

        #region customer

        private CustomerListViewModel _customerListViewModel;
        private CustomerService _customerService;

        #endregion

        #region skill

        private SkillListViewModel _skillListViewModel;
        private SkillService _skillService;

        #endregion

        #region EmployeeSkill

        private EmployeeSkillListViewModel _employeeSkillListViewModel;
        private EmployeeSkillService _employeeSkillService;
#endregion

    
        private RegionService _regionService;
        public HomeWindow()
        {
            InitializeComponent();

            #region employee

            _employeeService = new EmployeeService(new GcsContext());
            _employeeListViewModel = new EmployeeListViewModel(_employeeService);

            #endregion

            #region customer
            _customerService = new CustomerService(new GcsContext());
            _customerListViewModel = new CustomerListViewModel(_customerService);

            #endregion

            #region skill
            _skillService = new SkillService(new GcsContext());
            _skillListViewModel = new SkillListViewModel(_skillService);

            #endregion

            #region employeeskill
            _employeeSkillService = new EmployeeSkillService(new GcsContext());
            _employeeSkillListViewModel = new EmployeeSkillListViewModel(_employeeSkillService);

            #endregion


            _regionService = new RegionService(new GcsContext());

            //DataContext = _employeeListViewModel;
            SkillsListGrid.DataContext = _skillListViewModel;
            custListGrid.DataContext = _customerListViewModel;
            emplListGrid.DataContext = _employeeListViewModel;
            //CREATE REGION LIST VIEW

        }
        private void LoutCom(object sender, RoutedEventArgs e)
        {
            var mWin = new MainWindow();
            mWin.Show();
            this.Close();
        }

        private void BtnNewEmp_OnClick(object sender, RoutedEventArgs e)
        {
            var addEmpView = new AddEmployeeView(_employeeListViewModel, _employeeService, _regionService);
            addEmpView.Show();
        }

        private void BtnEmpList_OnClick(object sender, RoutedEventArgs e)
        {
           HideOtherGrids();
            emplListGrid.Visibility = Visibility.Visible;

        }

        private void BtnCustListShow_OnClick(object sender, RoutedEventArgs e)
        {
            HideOtherGrids();
            custListGrid.Visibility = Visibility.Visible;

        }

        private void HideOtherGrids()
        {
            custListGrid.Visibility = Visibility.Collapsed;
            ProjectsListGrid.Visibility = Visibility.Collapsed;
            emplListGrid.Visibility = Visibility.Collapsed;
            SkillsListGrid.Visibility = Visibility.Collapsed;
            RegionsListGrid.Visibility = Visibility.Collapsed;
            HomeGrid.Visibility = Visibility.Collapsed;
        }
        private void BtnShowSkillsList_OnClick(object sender, RoutedEventArgs e)
        {
           HideOtherGrids();
            SkillsListGrid.Visibility = Visibility.Visible;
        }

        private void BtnNewCust_OnClick(object sender, RoutedEventArgs e)
        {
            var addNewCustWin = new AddCustomerView(_customerListViewModel,_customerService,_regionService);
            addNewCustWin.Show();
        }

        private void BtnNewProj_OnClick(object sender, RoutedEventArgs e)
        {
            var addNewProj = new AddProjectWindow();
            addNewProj.Show();
        }


        private void BtnAddNewSkill_OnClick(object sender, RoutedEventArgs e)
        {
            var addNewSkill = new AddSkillView(_skillListViewModel,_skillService);
            addNewSkill.Show();
        }

        private void BtnShowProjectList_OnClick(object sender, RoutedEventArgs e)
        {
            HideOtherGrids();
            ProjectsListGrid.Visibility = Visibility.Visible;
        }

        private void RegionSettings(object sender, RoutedEventArgs e)
        {
            HideOtherGrids();
            RegionsListGrid.Visibility = Visibility.Visible;


        }

        private void BtnShowProjectSchedulesList_OnClick(object sender, RoutedEventArgs e)
        {
            var projSched = new ProjectSchedulesWindow();
            projSched.Show();
        }

        private void BtnShowBills_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnHome_OnClick(object sender, RoutedEventArgs e)
        {
            HideOtherGrids();
            HomeGrid.Visibility = Visibility.Visible;
        }
    }
}
