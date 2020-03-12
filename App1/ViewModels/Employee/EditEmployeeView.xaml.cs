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

namespace App1.ViewModels.Employee
{
    /// <summary>
    /// Interaction logic for EditEmployeeView.xaml
    /// </summary>
    public partial class EditEmployeeView : Window
    {
	    private EditEmployeeViewModel _toEditEmployee;
        private EditEmployeeView()
        {
            InitializeComponent();
        }

        public EditEmployeeView(EditEmployeeViewModel empToEdit) : this()
        {
	        DataContext = _toEditEmployee =empToEdit;
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            _toEditEmployee.Edit();
            Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
