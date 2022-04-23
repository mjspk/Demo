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

namespace Demo.Pages
{
    public partial class NetworkPage : CustomPage
    {
        NetworkViewModel viewModel;
        public NetworkPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new NetworkViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class NetworkViewModel : BaseViewModel
    {
       
        public NetworkViewModel(Page page)
        {
            Page = page;
            Emissions.Add(new Emission { ETH = "100", Number=1,UNT="100" });
            Emissions.Add(new Emission { ETH = "1000", Number = 2, UNT = "1000" });
            Emissions.Add(new Emission { ETH = "10000", Number = 3, UNT = "10000" });
            Emissions.Add(new Emission { ETH = "100000", Number = 4, UNT = "10000" });
        }
        public Command CancelCommand
        {
            get => new Command(Cancel);
        }

        private async void Cancel()
        {
           await Page.Navigation.PopAsync();
        }
        internal void OnAppearing()
        {
           
        }

        public Command TransactionsCommand
        {
            get => new Command(Transactions);
        }

        private async void Transactions()
        {
            await Page.Navigation.PushAsync(new TransactionsPage());
        }
        CustomCollection<Emission> _Emissions = new CustomCollection<Emission>();
        public CustomCollection<Emission> Emissions
        {
            get { return _Emissions; }
            set { SetProperty(ref _Emissions, value); }
        }
        public Page Page { get; }
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
