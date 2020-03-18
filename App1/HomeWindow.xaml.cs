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
using App1.ViewModels.Region;
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
	    #region EmployeeRegion

	    //private EmployeeRegionService employeeRegionService;
	    //private CustomerRegionService customerRegionService;

	    #endregion
        #region employee

        private EmployeeListViewModel _employeeListViewModel;
       // private EmployeeService _employeeService;

        #endregion

        #region customer

        private CustomerListViewModel _customerListViewModel;
       // private CustomerService _customerService;

        #endregion

        #region skill

        private SkillListViewModel _skillListViewModel;
        private SkillService _skillService;

        #endregion

        #region Region

        private RegionListViewModel _regionListViewModel;
        private RegionService _regionService;

        #endregion

        #region project

        private ProjectListViewModel _projectListViewModel;
        private ProjectService _projectService;

        #endregion

        private ProjCustEmpRegService _projCustEmpRegService;


        public HomeWindow()
        {
            InitializeComponent();

            _projCustEmpRegService = new ProjCustEmpRegService(new GcsContext());

            //employeeRegionService = new EmployeeRegionService(new GcsContext());
            //customerRegionService = new CustomerRegionService(new GcsContext());

            #region employee

            //_employeeService = new EmployeeService(new GcsContext());
            _employeeListViewModel = new EmployeeListViewModel(_projCustEmpRegService.EmployeeRegionService);

            #endregion

            #region customer
           //_customerService = _projCustEmpRegService.CustomerRegionService
            _customerListViewModel = new CustomerListViewModel(_projCustEmpRegService.CustomerRegionService);

            #endregion

            #region skill

            _skillService = _projCustEmpRegService.SkillService;
            _skillListViewModel = new SkillListViewModel(_skillService);

            #endregion

            #region Region

            _regionService = _projCustEmpRegService.EmployeeRegionService.RegionService;
            _regionListViewModel = new RegionListViewModel(_regionService);

            #endregion




            #region Project
            _projectService = new ProjectService(new GcsContext());
            _projectListViewModel = new ProjectListViewModel(_projCustEmpRegService);


            #endregion

            //DataContext = _employeeListViewModel;
            ProjectsListGrid.DataContext = _projectListViewModel;
            SkillsListGrid.DataContext = _skillListViewModel;
            custListGrid.DataContext = _customerListViewModel;
            emplListGrid.DataContext = _employeeListViewModel;
            RegionsListGrid.DataContext = _regionListViewModel;
            // EditEmpWin.DataContext = _employeeListViewModel.SelectedEmployee;
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
            var addEmpView = new AddEmployeeView(_employeeListViewModel, _projCustEmpRegService.EmployeeRegionService);
            addEmpView.ShowDialog();
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
            var addNewCustWin = new AddCustomerView(_customerListViewModel,_projCustEmpRegService.CustomerRegionService);
            addNewCustWin.Show();
        }

        private void BtnNewProj_OnClick(object sender, RoutedEventArgs e)
        {
            var addNewProj = new AddProjectWindow(_projectListViewModel,_projCustEmpRegService);
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

        private void BtnHome_OnClick(object sender, RoutedEventArgs e)
        {
	        HomeGrid.Visibility = Visibility.Visible;
        }

    }
}
