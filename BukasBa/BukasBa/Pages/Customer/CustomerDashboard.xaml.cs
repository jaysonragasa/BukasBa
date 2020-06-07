using BukasBa.CoreLibrary.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BukasBa.UI.Pages.Customer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerDashboard : ContentPage
    {
        public CustomerDashboard()
        {
            InitializeComponent();

            var t = Task.Run(async () => { await ((ViewModelLocator)this.BindingContext).Favorites.RefreshData(); });
            t.Wait();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            
        }
    }
}