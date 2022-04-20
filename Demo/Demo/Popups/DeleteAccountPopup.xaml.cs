using Demo.Models;
using Rg.Plugins.Popup.Exceptions;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteAccountPopup : PopupPage
    {
        private static DeleteAccountPopup popup;

        public Wallet Wallet { get; }

        public DeleteAccountPopup(Wallet wallet)
        {
            InitializeComponent();
            Wallet = wallet;
            BindingContext = this;
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public async void Hide()
        {
            await Navigation.RemovePopupPageAsync(popup);
        }
        public static async Task Show(Wallet wallet)
        {
            popup = new DeleteAccountPopup(wallet);
            await App.Current.MainPage.Navigation.ShowPopupAsDialog(popup);
        }


    }
    
}