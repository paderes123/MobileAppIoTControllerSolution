using CommunityToolkit.Mvvm.ComponentModel;
using MobileAppIoTController.Models;
using MobileAppIoTController.Services.Interfaces;

namespace MobileAppIoTController.ViewModels
{
    public partial class TemperatureViewModel : BaseViewModel
    {
        [ObservableProperty]
        private float _temperatureValue;

        private readonly IIoTService _ioTService;
        public TemperatureViewModel(IIoTService ioTService)
        {
            _ioTService = ioTService;
            Title = "Temperature";
            SubscribeToIoTStreamingEvents();
        }

        private void SubscribeToIoTStreamingEvents()
        {
            _ioTService.TemperatureDataChanged += OnTemperatureDataChanged;
            _ioTService.StartListeningForTemperatureUpdates();
        }

        private void OnTemperatureDataChanged(object? sender, Temperature temperature)
        {
            TemperatureValue = temperature.Value;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ioTService.StopListeningForTemperatureUpdates();
                _ioTService.TemperatureDataChanged -= OnTemperatureDataChanged;
            }
            base.Dispose(disposing);
        }
    }
}
