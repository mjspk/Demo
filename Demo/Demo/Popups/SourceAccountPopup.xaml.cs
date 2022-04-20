using Demo.Controls;
using Demo.Models;
using Demo.ViewModels;
using Rg.Plugins.Popup.Exceptions;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SourceAccountPopup : PopupPage
    {
        private static SourceAccountPopup popup;
        SourceAccountViewModel viewModel;
        public SourceAccountPopup()
        {
            InitializeComponent();
            BindingContext = viewModel= new SourceAccountViewModel(this);
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public async void Hide()
        {
            await Navigation.RemovePopupPageAsync(popup);
        }
        public static async Task<Wallet> Show()
        {
            popup = new SourceAccountPopup();
            await App.Current.MainPage.Navigation.ShowPopupAsDialog(popup);
            return popup.viewModel.Wallet;
        }


    }
    public class SourceAccountViewModel : BaseViewModel
    {
        public SourceAccountViewModel(SourceAccountPopup popup)
        {
            Wallets.Add(new Wallet
            {
                Id = Guid.NewGuid(),
                Unts = 5005,
                IconCode = "47F0",
                Name = "Main ultranet wallet",
                AccountColor = Color.FromHex("#6601e3"),
            });
            Wallets.Add(new Wallet
            {
                Id = Guid.NewGuid(),
                Unts = 5005,
                IconCode = "2T52",
                Name = "Primary ultranet wallet",
                AccountColor = Color.FromHex("#3765f4"),

            });
            Wallets.Add(new Wallet
            {
                Id = Guid.NewGuid(),
                Unts = 5005,
                IconCode = "9MDL",
                Name = "Secondary wallet",
                AccountColor = Color.FromHex("#4cb16c"),

            });
            Wallets.Add(new Wallet
            {
                Id = Guid.NewGuid(),
                Unts = 5005,
                IconCode = "UYO3",
                Name = "Main ultranet wallet",
                AccountColor = Color.FromHex("#e65c93"),

            });
            Wallets.Add(new Wallet
            {
                Id = Guid.NewGuid(),
                Unts = 5005,
                IconCode = "47FO",
                Name = "Main ultranet wallet",
                AccountColor = Color.FromHex("#ba918c"),

            });
            Wallets.Add(new Wallet
            {
                Id = Guid.NewGuid(),
                Unts = 5005,
                IconCode = "2T52",
                Name = "Main ultranet wallet",
                AccountColor = Color.FromHex("#d56a48"),

            });
            Wallets.Add(new Wallet
            {
                Id = Guid.NewGuid(),
                Unts = 5005,
                IconCode = "47FO",
                Name = "Main ultranet wallet",
                AccountColor = Color.FromHex("#56d7de"),

            });
            Wallets.Add(new Wallet
            {
                Id = Guid.NewGuid(),
                Unts = 5005,
                IconCode = "2T52",
                Name = "Main ultranet wallet",
                AccountColor = Color.FromHex("#bb50dd"),

            });
            Popup = popup;
        }
        public Command CloseCommad
        {
            get => new Command(Close);
        }

        private void Close()
        {
           Popup.Hide();
        }
        CustomCollection<Wallet> _Wallets = new CustomCollection<Wallet>();
        public CustomCollection<Wallet> Wallets
        {
            get { return _Wallets; }
            set { SetProperty(ref _Wallets, value); }
        }
        public Page Page { get; }
        public Command ItemTppedCommand
        {
            get => new Command<Wallet>(ItemTpped);
        }
        private void ItemTpped(Wallet wallet)
        {
            foreach (var item in Wallets)
            {
                item.IsSelected = false;
            }
            wallet.IsSelected = true;
        }
        
        Wallet _Wallet = new Wallet
        {
            Id = Guid.NewGuid(),
            Unts = 5005,
            IconCode = "47F0",
            Name = "Main ultranet wallet",
            AccountColor = Color.FromHex("#6601e3"),
        };
        public Wallet Wallet
        {
            get { return _Wallet; }
            set { SetProperty(ref _Wallet, value); }
        }

        public SourceAccountPopup Popup { get; }
    }

}