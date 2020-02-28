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

namespace App1
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }
        private void LoutCom(object sender, RoutedEventArgs e)
        {
            var mWin = new MainWindow();
            mWin.Show();
            this.Close();
        }

        private void BtnNewEmp_OnClick(object sender, RoutedEventArgs e)
        {
            var addnewEmpWin = new AddEmployeeWindow();
            addnewEmpWin.Show();
        }

        private void BtnEmpList_OnClick(object sender, RoutedEventArgs e)
        {
            emplListGrid.Visibility = Visibility.Visible;


            custListGrid.Visibility = Visibility.Hidden;
        }

        private void BtnNewCust_OnClick(object sender, RoutedEventArgs e)
        {
            custListGrid.Visibility = Visibility.Visible;
        }
    }
}
