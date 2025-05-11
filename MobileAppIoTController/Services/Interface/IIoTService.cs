using MobileAppIoTController.Models;

namespace MobileAppIoTController.Services.Interfaces
{
    public interface IIoTService
    {
        event EventHandler<Temperature>? TemperatureDataChanged;
        void StartListeningForTemperatureUpdates();
        void StopListeningForTemperatureUpdates();
        Task SaveTextMessageAsync(TextMessage textMessage);
        Task SaveSwitchStateAsync(SwitchStates switchStates);
    }
}



