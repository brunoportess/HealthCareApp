using HealthCareApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HealthCareApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCardPage : ContentPage
    {
        public MyCardPage()
        {
            InitializeComponent();
            BindingContext = new MyCardViewModel();
        }
    }
}