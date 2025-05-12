
using MobileAppIoTController.ViewModels;

namespace MobileAppIoTController.Views;

public partial class TextMessagePage : ContentPage
{
	public TextMessagePage(TextMessageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}


