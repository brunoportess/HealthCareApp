
using System.Threading.Tasks;
using HealthCareApp.Helpers;
using Xamarin.Forms;

namespace HealthCareApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public AsyncCommand AuthCommand { get; }
        public LoginViewModel()
        {
            AuthCommand = new AsyncCommand(AuthCommandExecute);
        }

        private async Task AuthCommandExecute()
        {
            Authentication.SetAuthenticate(true);
            //await Navigation.GoToRootAsync();
            await Navigation.GoToAsync("//HomeViewModel");
        }
    }
}
