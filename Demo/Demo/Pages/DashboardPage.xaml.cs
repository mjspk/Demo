using Demo.Controls;
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
    public partial class DashboardPage : CustomPage
    {
        DashboardViewModel viewModel;
        public DashboardPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new DashboardViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel(Page page)
        {
            Page = page;
            Wallets.Add(new Wallet
            {
                Id = Guid.NewGuid(),
                Unts = 5005,
                IconCode = "47F0",
                Name = "Main ultranet"
            });
            Wallets.Add(new Wallet
            {
                Id = Guid.NewGuid(),
                Unts = 5005,
                IconCode = "2T52",
                Name = "Main ultranet"
            });
            Wallets.Add(new Wallet
            {
                Id = Guid.NewGuid(),
                Unts = 5005,
                IconCode = "9MDL",
                Name = "Main ultranet"
            });

            Transactions.Add(new Transaction
            {
                FromId = Generator.GenerateUniqueID(6),
                ToId = Generator.GenerateUniqueID(6),
                Unt = 540,
                Name = "UNT Transfer",
                Status = TransactionsStatus.Pending
            });
            Transactions.Add(new Transaction
            {
                FromId = Generator.GenerateUniqueID(6),
                ToId = Generator.GenerateUniqueID(6),
                Unt = 590,
                Name = "UNT Transfer",
                Status = TransactionsStatus.Sent
            });
            Transactions.Add(new Transaction
            {
                FromId = Generator.GenerateUniqueID(6),
                ToId = Generator.GenerateUniqueID(6),
                Unt = 590,
                Name = "UNT Transfer",
                Status = TransactionsStatus.Failed
            });
        }
        internal void OnAppearing()
        {

        }
        public Command AuthorsCommand
        {
            get => new Command(AuthorsExcute);
        }
        public async void AuthorsExcute()
        {
            await Page.Navigation.PushAsync(new AuthorsPage());
        }
        public Command ProductsCommand
        {
            get => new Command(ProductsExcute);
        }
        public async void ProductsExcute()
        {
            await Page.Navigation.PushAsync(new ProductsPage());
        }
        public Command ETHTransferCommand
        {
            get => new Command(ETHTransferExcute);
        }
        public async void ETHTransferExcute()
        {
            await Page.Navigation.PushAsync(new ETHTransferPage());
        }
        public Command TransactionsCommand
        {
            get => new Command(TransactionsCommandExcute);
        }
        public async void TransactionsCommandExcute()
        {
            await Page.Navigation.PushAsync(new TransactionsPage());
        }
        public Command AccountsCommand
        {
            get => new Command(AccountsCommandExcute);
        }
        public async void AccountsCommandExcute()
        {
            await Page.Navigation.PushAsync(new ManageAccountsPage());
        }
        CustomCollection<Wallet> _Wallets =new CustomCollection<Wallet>();
        public CustomCollection<Wallet>  Wallets
        {
            get { return _Wallets; }
            set { SetProperty(ref _Wallets, value); }
        }
        CustomCollection<Transaction> _Transactions = new CustomCollection<Transaction>();
        public CustomCollection<Transaction> Transactions
        {
            get { return _Transactions; }
            set { SetProperty(ref _Transactions, value); }
        }

        public Page Page { get; }
    }
}
