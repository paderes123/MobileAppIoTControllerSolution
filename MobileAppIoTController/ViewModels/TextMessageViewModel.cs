using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileAppIoTController.Services.Interfaces;
using Syncfusion.Maui.Chat;
using System.Collections.ObjectModel;

namespace MobileAppIoTController.ViewModels
{
    public partial class TextMessageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Author _sender;

        [ObservableProperty]
        public ObservableCollection<object> _textMessages = new();

        private readonly IIoTService _ioTService;
        public TextMessageViewModel(IIoTService ioTService)
        {
            _ioTService = ioTService;
            Title = "Text Message";
        }

        [RelayCommand]
        async Task SaveTextMessageAsync(object args)
        {
            try
            {
                if (args is not SendMessageEventArgs messageTappedArgs)
                    return;

                string? message = messageTappedArgs.Message?.Text;

                if (string.IsNullOrEmpty(message))
                    return;

                await _ioTService.SaveTextMessageAsync(new Models.TextMessage() { Value = message });

                TextMessages.Add(new Syncfusion.Maui.Chat.TextMessage
                {
                    Author = Sender,
                    Text = message
                });
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to save message: {ex.Message}", "OK");
            }
        }

    }
}
