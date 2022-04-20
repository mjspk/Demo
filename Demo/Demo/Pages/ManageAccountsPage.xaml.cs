using Demo.Controls;
using Demo.Helpers;
using Demo.Models;
using Demo.Popups;
using Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Xamarin.Essentials.AppleSignInAuthenticator;

namespace Demo.Pages
{
    public partial class ManageAccountsPage : CustomPage
    {
        ManageAccountsViewModel viewModel;
        public ManageAccountsPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new ManageAccountsViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class ManageAccountsViewModel : BaseViewModel
    {
       
        public ManageAccountsViewModel(Page page)
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
            Page = page;
        }
        public Command CreateCommand
        {
            get => new Command(Create);
        }

        private async void Create()
        {
            await Page.Navigation.PushModalAsync(new CreateAccountPage());
        }
        public Command RestoreCommand
        {
            get => new Command(Restore);
        }

        private async void Restore()
        {
            await Page.Navigation.PushAsync(new RestoreAccountPage());
        }
        public Command ItemTappedCommand
        {
            get => new Command<Wallet>(ItemTapped);
        }

        private async void ItemTapped(Wallet wallet)
        {
            if (wallet == null) 
                return;
            await Page.Navigation.PushAsync(new AccountDetailsPage(wallet));
        }
        public Command OptionsCommand
        {
            get => new Command<Wallet>(Options);
        }

        private async void Options(Wallet wallet)
        {
            await AccountOptionsPopup.Show(wallet);
        }
        internal void OnAppearing()
        {
           
        }
        Wallet _SelectedItem ;
        public Wallet SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(ref _SelectedItem, value); }
        }
        CustomCollection<Wallet> _Wallets =new CustomCollection<Wallet>();
        public CustomCollection<Wallet>  Wallets
        {
            get { return _Wallets; }
            set { SetProperty(ref _Wallets, value); }
        }

        public Page Page { get; }
    }
}
