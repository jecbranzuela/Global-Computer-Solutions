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

namespace App1.ViewModels.Customer
{
    /// <summary>
    /// Interaction logic for AddCustomerView.xaml
    /// </summary>
    public partial class AddCustomerView : Window
    {
        private AddCustomerViewModel _toAddCustomer;
        public AddCustomerView()
        {
            InitializeComponent();
        }

        public AddCustomerView(CustomerListViewModel customerListViewModel,
            CustomerRegionService customerRegionService) :this()
        {
            _toAddCustomer = new AddCustomerViewModel(customerRegionService.CustomerService, customerRegionService.RegionService, customerListViewModel);

            DataContext = _toAddCustomer;
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _toAddCustomer.Add();
            MessageBox.Show("Succesfully Added.");
            this.Close();
        }
    }
}
