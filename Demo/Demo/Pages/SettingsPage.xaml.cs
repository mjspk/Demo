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
    public partial class SettingsPage : CustomPage
    {
        SettingsViewModel viewModel;
        public SettingsPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new SettingsViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class SettingsViewModel : BaseViewModel
    {
       
        public SettingsViewModel(Page page)
        {
            Page = page;
            Months.Add("April");
            Months.Add("May");
            Months.Add("June");
            Months.Add("July");
            Months.Add("Augest");
            Months.Add("Spetemper");
            Months.Add("November");

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
        CustomCollection<string> _Months = new CustomCollection<string>();
        public CustomCollection<string> Months
        {
            get { return _Months; }
            set { SetProperty(ref _Months, value); }
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
