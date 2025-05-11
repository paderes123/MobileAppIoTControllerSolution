using Firebase.Database;
using Firebase.Database.Query;
using MobileAppIoTController.Models;
using MobileAppIoTController.Services.Interfaces;
namespace MobileAppIoTController.Services
{
    public class FirebaseIoTService : IIoTService
    {
        private FirebaseClient _firebaseClient = null!;
        private IDisposable? _temperatureSubscription;

        public event EventHandler<Temperature>? TemperatureDataChanged;

        public FirebaseIoTService()
        {
            InitializeFirebaseClient();
        }

        private void InitializeFirebaseClient()
        {
            _firebaseClient = new FirebaseClient("https://mobileappiotcontrollerdb-default-rtdb.asia-southeast1.firebasedatabase.app/");
        }

        public async Task SaveSwitchStateAsync(SwitchStates switchStates)
        {
            await _firebaseClient
                .Child("IoTControllerDB")
                .Child("Device1")
                .Child("SwitchStates")
                .PutAsync(switchStates);
        }

        public void StartListeningForTemperatureUpdates()
        {
            // Stop any existing subscription to avoid duplicates
            StopListeningForTemperatureUpdates();

            // Subscribe to real-time updates for the PowerMeter node
            _temperatureSubscription = _firebaseClient
            .Child("IoTControllerDB")
            .Child("Device2")
            .AsObservable<Temperature>()
            .Subscribe(
                p =>
                {
                    Temperature temperatureData = p.Object;
                    TemperatureDataChanged?.Invoke(this, temperatureData);
                }
            );
        }

        public async Task SaveTextMessageAsync(TextMessage textMessage)
        {
            await _firebaseClient
                .Child("IoTControllerDB")
                .Child("Device3")
                .Child("TextMessage")
                .PutAsync(textMessage);
        }

        public void StopListeningForTemperatureUpdates()
        {
            _temperatureSubscription?.Dispose();
            _temperatureSubscription = null;
        }
    }
}
