
using MobileAppIoTController.ViewModels;

namespace MobileAppIoTController.Views;

public partial class TemperaturePage : ContentPage
{
	public TemperaturePage(TemperatureViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}



