namespace MobileAppIoTController
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mzg0NDA5NkAzMjM5MmUzMDJlMzAzYjMyMzkzYlVZZWV1cTFDeGJsNFpXSUsrUnNWRGVnRm1VdVBsTjJXcjY5Ykh6dUZaTzg9");
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}