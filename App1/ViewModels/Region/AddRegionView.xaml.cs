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

namespace App1.ViewModels.Region
{
    /// <summary>
    /// Interaction logic for AddRegionView.xaml
    /// </summary>
    public partial class AddRegionView : Window
    {
	    private AddRegionViewModel _toAddRegion;
        public AddRegionView()
        {
            InitializeComponent();
        }

        public AddRegionView(RegionListViewModel regionListViewModel,RegionService regionService) :this()
        {
	        DataContext = _toAddRegion = new AddRegionViewModel(regionService,regionListViewModel);
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            _toAddRegion.Add();
            this.Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
