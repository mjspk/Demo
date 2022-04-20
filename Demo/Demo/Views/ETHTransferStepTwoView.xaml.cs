using Demo.Controls;
using Demo.Models;
using Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ETHTransferStepTwoView : ContentView
    {
        ETHTransferStepTwoViewModel _viewModel;
        public ETHTransferStepTwoView()
        {
            InitializeComponent();
            BindingContext= _viewModel= new ETHTransferStepTwoViewModel();
        }
    }
    public class ETHTransferStepTwoViewModel : BaseViewModel
    {
        public ETHTransferStepTwoViewModel()
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

        }
        CustomCollection<Wallet> _Wallets = new CustomCollection<Wallet>();
        public CustomCollection<Wallet> Wallets
        {
            get { return _Wallets; }
            set { SetProperty(ref _Wallets, value); }
        }
        public Page Page { get; }
        AccountColor _SelectedAccountColor;
        public AccountColor SelectedAccountColor
        {
            get { return _SelectedAccountColor; }
            set { SetProperty(ref _SelectedAccountColor, value); }
        }
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
        public Command ShowHideAccountsCommand
        {
            get => new Command(ShowHideAccounts);
        }
        private void ShowHideAccounts()
        {
            AccountsShown = !AccountsShown;
        }
        bool _ShowHideAccounts;
        public bool AccountsShown
        {
            get { return _ShowHideAccounts; }
            set { SetProperty(ref _ShowHideAccounts, value); }
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

    }
}