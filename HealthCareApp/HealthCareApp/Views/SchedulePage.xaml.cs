using HealthCareApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthCareApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();
            BindingContext = new ScheduleViewModel();
        }
    }
}