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

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
	        var RegionListContext = (RegionListViewModel)DataContext;
            var addRegion = new AddRegionView(RegionListContext,RegionListContext.ReturnContext());
            addRegion.Show();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
	        var RegionListContext = (RegionListViewModel)DataContext;
            var edRegion = new EditRegionView(RegionListContext.EditRegionViewModel());
            edRegion.Show();
            //var edRegion 
        }
    }
}
