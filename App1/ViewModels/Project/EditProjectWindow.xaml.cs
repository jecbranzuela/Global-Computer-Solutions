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

namespace App1.ViewModels.Project
{
    /// <summary>
    /// Interaction logic for EditProjectWindow.xaml
    /// </summary>
    public partial class EditProjectWindow : Window
    {
	    private readonly EditProjectViewModel _toEditProject;
        private EditProjectWindow()
        {
            InitializeComponent();
        }

        public EditProjectWindow(EditProjectViewModel projectToEdit):this()
        {
	        DataContext = _toEditProject = projectToEdit;
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
	        _toEditProject.Edit();
            Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
	        Close();
        }
    }
}
