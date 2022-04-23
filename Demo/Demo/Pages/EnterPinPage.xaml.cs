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
    public partial class EnterPinPage : CustomPage
    {
        EnterPinViewModel viewModel;
        public EnterPinPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new EnterPinViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class EnterPinViewModel : BaseViewModel
    {
       
        public EnterPinViewModel(Page page)
        {
            Page = page;           

        }
        public Command DeleteCommand
        {
            get => new Command(Delete);
        }

        private async void Delete()
        {
           await DeleteAccountPopup.Show(Wallet);
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
