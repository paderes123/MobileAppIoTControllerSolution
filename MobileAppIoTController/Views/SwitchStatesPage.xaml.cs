using MobileAppIoTController.ViewModels;

namespace MobileAppIoTController.Views;

public partial class SwitchStatesPage : ContentPage
{
	public SwitchStatesPage(SwitchStatesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}


