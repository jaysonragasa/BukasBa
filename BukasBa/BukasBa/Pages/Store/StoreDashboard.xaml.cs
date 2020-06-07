using BukasBa.CoreLibrary.ViewModels;
using System.Threading.Tasks;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var t = Task.Run(async () => { await ((ViewModelLocator)this.BindingContext).StoreDashboard.RefreshData(); });
            t.Wait();
        }
    }
}