using System.Windows;

namespace App1.ViewModels.Customer
{
	/// <summary>
	///     Interaction logic for EditCustomerView.xaml
	/// </summary>
	public partial class EditCustomerView : Window
	{
		private readonly EditCustomerViewModel _toEditCustomer;

		private EditCustomerView()
		{
			InitializeComponent();
		}

		public EditCustomerView(EditCustomerViewModel customerToEdit) : this()
		{
			DataContext = _toEditCustomer = customerToEdit;
		}

		private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void BtnSave_OnClick(object sender, RoutedEventArgs e)
		{
			_toEditCustomer.Edit();
			Close();
		}
	}
}