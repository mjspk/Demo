using Demo.Controls;
using Demo.Helpers;
using Demo.Models;
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
    public partial class CreateAccountPage : CustomPage
    {
        CreateAccountViewModel viewModel;
        public CreateAccountPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new CreateAccountViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class CreateAccountViewModel : BaseViewModel
    {
       
        public CreateAccountViewModel(Page page)
        {
            Page = page;
            Colors.Add(new AccountColor { Color= Color.FromHex("#6601e3") ,BoderColor= Page.BackgroundColor });
            Colors.Add(new AccountColor { Color = Color.FromHex("#3765f4"), BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#4cb16c"),  BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#ba918c"), BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#d56a48"),  BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#56d7de"), BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#bb50dd"), BoderColor = Color.Transparent });
         

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
        public Command CloseCommad
        {
            get => new Command(Close);
        }

        private async void Close()
        {
            await Page.Navigation.PopModalAsync();
        }
        public Command PrevCommand
        {
            get => new Command(Prev);
        }
        private void Prev()
        {
            Position -= 1;
        }
        public Command NextCommad
        {
            get => new Command(Next);
        }
        private void Next()
        {
            if (Position == 1) return;
            Position += 1;
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
        AccountColor _SelectedAccountColor;
        public AccountColor SelectedAccountColor
        {
            get { return _SelectedAccountColor; }
            set { SetProperty(ref _SelectedAccountColor, value); }
        }
         int _Position;
        public int Position
        {
            get { return _Position; }
            set { SetProperty(ref _Position, value); }
        }
        Wallet _Wallet=new Wallet();
        public Wallet Wallet
        {
            get { return _Wallet; }
            set { SetProperty(ref _Wallet, value); }
        }
        
    }
}
