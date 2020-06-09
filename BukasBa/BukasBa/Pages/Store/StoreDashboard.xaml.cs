using BukasBa.CoreLibrary.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BukasBa.UI.Pages.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreDashboard : ContentPage
    {
        public StoreDashboard()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ((ViewModelLocator)this.BindingContext).StoreDashboard.RefreshData();
        }
    }
}