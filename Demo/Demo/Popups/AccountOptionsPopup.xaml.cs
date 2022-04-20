using Demo.Models;
using Demo.Pages;
using Rg.Plugins.Popup.Exceptions;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountOptionsPopup : PopupPage
    {
        private static AccountOptionsPopup popup;

        public Wallet Wallet { get; }

        public AccountOptionsPopup(Wallet wallet)
        {
            InitializeComponent();
            Wallet = wallet;
            BindingContext = this;
        }
        public Command SendCommand
        {
            get => new Command(Send);
        }

        private async void Send()
        {
            await Navigation.PushAsync(new SendPage());
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
            popup = new AccountOptionsPopup(wallet);
            await App.Current.MainPage.Navigation.ShowPopupAsDialog(popup);
        }


    }
    
}