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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace App1.ViewModels.Customer
{
    /// <summary>
    /// Interaction logic for CustomerTabView.xaml
    /// </summary>
    public partial class CustomerTabView : UserControl
    {
        public CustomerTabView()
        {
            InitializeComponent();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            var custListContext = (CustomerListViewModel)DataContext;
            var edCust = new EditCustomerView(custListContext.CreateEditCustomerViewModel());
            edCust.Show();
        }
    }
}
