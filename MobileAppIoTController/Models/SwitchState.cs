using CommunityToolkit.Mvvm.ComponentModel;

namespace MobileAppIoTController.Models
{
    public partial class SwitchStates : ObservableObject
    {
        [ObservableProperty]
        private bool _switch1;

        [ObservableProperty]
        private bool _switch2;

        [ObservableProperty]
        private bool _switch3;

        [ObservableProperty]
        private bool _switch4;

        [ObservableProperty]
        private bool _switch5;
    }
}