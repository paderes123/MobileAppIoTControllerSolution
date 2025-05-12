using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileAppIoTController.Models;
using MobileAppIoTController.Services.Interfaces;

namespace MobileAppIoTController.ViewModels
{
    public partial class SwitchStatesViewModel : BaseViewModel
    {
        private readonly IIoTService _ioTService;

        [ObservableProperty]
        private SwitchStates _switchStates = new();

        public SwitchStatesViewModel(IIoTService ioTService)
        {
            _ioTService = ioTService;
            Title = "Switch States";
        }

        [RelayCommand]
        private async Task Switch1StateChanged() => await UpdateSwitchStates();

        [RelayCommand]
        private async Task Switch2StateChanged() => await UpdateSwitchStates();

        [RelayCommand]
        private async Task Switch3StateChanged() => await UpdateSwitchStates();

        [RelayCommand]
        private async Task Switch4StateChanged() => await UpdateSwitchStates();

        [RelayCommand]
        private async Task Switch5StateChanged() => await UpdateSwitchStates();

        private async Task UpdateSwitchStates() => await _ioTService.SaveSwitchStateAsync(SwitchStates);
    }
}
