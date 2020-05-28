using HealthCareApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthCareApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAppointmentsPage : ContentPage
    {
        public MyAppointmentsPage()
        {
            InitializeComponent();
            BindingContext = new MyAppointmentsViewModel();
        }
    }
}