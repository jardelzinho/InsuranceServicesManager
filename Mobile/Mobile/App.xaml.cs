using Mobile.Core.Services.Navigation;
using Mobile.Core.Services.Settings;
using Mobile.Core.ViewModels.Base;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    public partial class App : Application
    {
        ISettingsService _settingsService;

        public App()
        {
            InitializeComponent();

            //InitApp();
            //if (Device.RuntimePlatform == Device.UWP)
            //{
            //    InitNavigation();
            //}
        }

        private void InitApp()
        {
            _settingsService = ViewModelLocator.Resolve<ISettingsService>();
            if (!_settingsService.UseMocks)
                ViewModelLocator.UpdateDependencies(_settingsService.UseMocks);
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            base.OnStart();
            InitApp();
            if (Device.RuntimePlatform != Device.UWP)
            {
                await InitNavigation();
            }
            if (_settingsService.AllowGpsLocation && !_settingsService.UseFakeLocation)
            {
                //await GetGpsLocation();
            }
            if (!_settingsService.UseMocks && !string.IsNullOrEmpty(_settingsService.AuthAccessToken))
            {
                //await SendCurrentLocation();
            }

            base.OnResume();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
