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

namespace App1.ViewModels.Region
{
    /// <summary>
    /// Interaction logic for RegionTabView.xaml
    /// </summary>
    public partial class RegionTabView : UserControl
    {
        public RegionTabView()
        {
            InitializeComponent();
            lbCust.Items.Clear();
            lbEmp.Items.Clear();
        }
    }
}
