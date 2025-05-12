using CommunityToolkit.Mvvm.ComponentModel;

namespace MobileAppIoTController.ViewModels
{
    public partial class BaseViewModel : ObservableObject, IDisposable
    {
        [ObservableProperty]
        string _title;

        // Virtual Dispose method for cleanup
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources here if any
            }
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Prevent finalizer from running
        }
    }
}
