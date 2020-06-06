using BukasBa.CoreLibrary.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BukasBa.UI.Pages.Customer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreLists : ContentPage
    {
        public StoreLists()
        {
            InitializeComponent();

            ((ViewModelLocator)this.BindingContext).StoreLists.RefreshData();
        }
    }
}