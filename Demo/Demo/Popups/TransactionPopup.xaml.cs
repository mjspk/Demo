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
    public partial class TransactionPopup : PopupPage
    {
        private static TransactionPopup popup;

        public Transaction Transaction { get; }
        public Wallet Wallet { get; }

        public TransactionPopup(Transaction  transaction)
        {
            InitializeComponent();
            Transaction = transaction;
            Wallet = transaction.Wallet;
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
        public static async Task Show(Transaction transaction)
        {
            popup = new TransactionPopup(transaction);
            await App.Current.MainPage.Navigation.ShowPopupAsDialog(popup);
        }


    }
    
}