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
using App1.ViewModels.Skill;

namespace App1.ViewModels.Region
{
    /// <summary>
    /// Interaction logic for EditRegionView.xaml
    /// </summary>
    public partial class EditRegionView : Window
    {
	    private EditRegionViewModel _toEditRegion;
        public EditRegionView()
        {
            InitializeComponent();
        }

        public EditRegionView(EditRegionViewModel regionToEdit) :this()
        {
	        DataContext = _toEditRegion = regionToEdit;
        }
        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            _toEditRegion.Edit();
            this.Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
	        this.Close();
        }
    }
}
