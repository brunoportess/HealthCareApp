using HealthCareApp.Helpers;
using HealthCareApp.Services;
using HealthCareApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HealthCareApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            var nav = NavigationService.Current;
            var lastLocation = Preferences.Get("LastKnownUrl", string.Empty);
            await nav.GoToAsync(new ShellNavigationState(nameof(LoginViewModel)));
            /*if (!Authentication.IsAuthenticated())
            {
                await nav.GoToAsync(new ShellNavigationState(nameof(LoginViewModel)));
            }

            if (string.IsNullOrEmpty(lastLocation))
                return;
            
            await nav.GoToAsync(new ShellNavigationState(lastLocation));*/
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
