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
    public partial class AccountDetailsPage : CustomPage
    {
        AccountDetailsViewModel viewModel;
        public AccountDetailsPage(Wallet wallet)
        {
            InitializeComponent();
            BindingContext=viewModel=new AccountDetailsViewModel(this,wallet);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class AccountDetailsViewModel : BaseViewModel
    {
       
        public AccountDetailsViewModel(Page page, Wallet wallet)
        {
            Page = page;
            Wallet = wallet;

            Colors.Add(new AccountColor { Color= Color.FromHex("#6601e3") ,BoderColor= Page.BackgroundColor });
            Colors.Add(new AccountColor { Color = Color.FromHex("#3765f4"), BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#4cb16c"),  BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#ba918c"), BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#d56a48"),  BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#56d7de"), BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#bb50dd"), BoderColor = Color.Transparent });
            Authors.Add(new Author { Name = "ultranet" });
            Authors.Add(new Author { Name = "ultranetorganization" });
            Authors.Add(new Author { Name = "aximion" });
            Products.Add(new Product { Name = "UNS" });
            Products.Add(new Product { Name = "Aximion3D" });
            Products.Add(new Product { Name = "ultranet" });


        }
        public Command SendCommand
        {
            get => new Command(Send);
        }

        private async void Send()
        {
            await Page.Navigation.PushAsync(new SendPage());
        }
        public Command ShowKeyCommand
        {
            get => new Command(ShowKey);
        }

        private async void ShowKey()
        {
            await Page.Navigation.PushAsync(new PrivateKeyPage(Wallet));
        }
        public Command DeleteCommand
        {
            get => new Command(Delete);
        }

        private async void Delete()
        {
            await Page.Navigation.PushAsync(new DeleteAccountPage(Wallet));
        }
        public Command ColorTappedCommand
        {
            get => new Command<AccountColor>(ColorTapped);
        }

        private void ColorTapped(AccountColor obj)
        {

            foreach (var item in Colors)
            {
                item.BoderColor = Color.Transparent;
                Colors.ReportItemChange(item);
            }
            obj.BoderColor =Page.BackgroundColor;
            Colors.ReportItemChange(obj);
            Wallet.AccountColor = obj.Color;
        }

        internal void OnAppearing()
        {
           
        }
        CustomCollection<AccountColor> _Colors = new CustomCollection<AccountColor>();
        public CustomCollection<AccountColor> Colors
        {
            get { return _Colors; }
            set { SetProperty(ref _Colors, value); }
        }
        CustomCollection<Author> _Authors = new CustomCollection<Author>();
        public CustomCollection<Author> Authors
        {
            get { return _Authors; }
            set { SetProperty(ref _Authors, value); }
        }
        CustomCollection<Product> _Products = new CustomCollection<Product>();
        public CustomCollection<Product> Products
        {
            get { return _Products; }
            set { SetProperty(ref _Products, value); }
        }


        public Page Page { get; }
        Wallet _Wallet;
        public Wallet Wallet
        {
            get { return _Wallet; }
            set { SetProperty(ref _Wallet, value); }
        }
       
    }
}
