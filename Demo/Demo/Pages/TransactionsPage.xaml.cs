using Demo.Controls;
using Demo.Models;
using Demo.Popups;
using Demo.ViewModels;
using System;
using Xamarin.Forms;

namespace Demo.Pages
{
    public partial class TransactionsPage : CustomPage
    {
        TransactionsViewModel viewModel;
        public TransactionsPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new TransactionsViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class TransactionsViewModel : BaseViewModel
    {
       
        public TransactionsViewModel(Page page)
        {
            Transactions.Add(new Transaction
            {
                FromId = Generator.GenerateUniqueID(6),
                ToId = Generator.GenerateUniqueID(6),
                Unt = 540,
                Name = "Register ultranetorg author",
                Status = TransactionsStatus.Pending,
                USD=185.35,
                Hash = "0x63FaC9201494f0bd17B9892B9fad52fe3BD377",

                Wallet = new Wallet
                {
                    Id = Guid.NewGuid(),
                    Unts = 5005,
                    IconCode = "47F0",
                    Name = "Main ultranet wallet",
                    AccountColor = Color.FromHex("#6601e3"),
                }
            });
            Transactions.Add(new Transaction
            {
                FromId = Generator.GenerateUniqueID(6),
                ToId = Generator.GenerateUniqueID(6),
                Unt = 590,
                Name = "Sent to 0xAA...FF00",
                Status = TransactionsStatus.Sent,
                USD = 85.33,
                Hash = "0x63FaC9201494f0bd17B9892B9fad52fe3BD377",

                Wallet = new Wallet
                {
                    Id = Guid.NewGuid(),
                    Unts = 5005,
                    IconCode = "47F0",
                    Name = "Main ultranet wallet",
                    AccountColor = Color.FromHex("#6601e3"),
                }

            });
            Transactions.Add(new Transaction
            {
                FromId = Generator.GenerateUniqueID(6),
                ToId = Generator.GenerateUniqueID(6),
                Unt = 590,
                Name = "Recieve from 0xAA...FF00",
                Status = TransactionsStatus.Received,
                USD = 85.33,
                Hash = "0x63FaC9201494f0bd17B9892B9fad52fe3BD377",

                Wallet = new Wallet
                {
                    Id = Guid.NewGuid(),
                    Unts = 5005,
                    IconCode = "47F0",
                    Name = "Main ultranet wallet",
                    AccountColor = Color.FromHex("#6601e3"),
                }

            });
            Transactions.Add(new Transaction
            {
                FromId = Generator.GenerateUniqueID(6),
                ToId = Generator.GenerateUniqueID(6),
                Unt = 540,
                Name = "Sent to 0xAA...FF00",
                Status = TransactionsStatus.Sent,
                USD = 185.44,
                Hash = "0x63FaC9201494f0bd17B9892B9fad52fe3BD377",

                Wallet = new Wallet
                {
                    Id = Guid.NewGuid(),
                    Unts = 5005,
                    IconCode = "47F0",
                    Name = "Main ultranet wallet",
                    AccountColor = Color.FromHex("#6601e3"),
                }

            });
            Transactions.Add(new Transaction
            {
                FromId = Generator.GenerateUniqueID(6),
                ToId = Generator.GenerateUniqueID(6),
                Unt = 590,
                Name = "Register ultranetorg author",
                Status = TransactionsStatus.Pending,
                USD = 85.33,
                Hash= "0x63FaC9201494f0bd17B9892B9fad52fe3BD377",
                Wallet= new Wallet
                {
                    Id = Guid.NewGuid(),
                    Unts = 5005,
                    IconCode = "47F0",
                    Name = "Main ultranet wallet",
                    AccountColor = Color.FromHex("#6601e3"),
                }

            });
            Transactions.Add(new Transaction
            {
                FromId = Generator.GenerateUniqueID(6),
                ToId = Generator.GenerateUniqueID(6),
                Unt = 590,
                Name = "Recieve from 0xAA...FF00",
                Status = TransactionsStatus.Received,
                USD = 185.55,
                Wallet = new Wallet
                {
                    Id = Guid.NewGuid(),
                    Unts = 5005,
                    IconCode = "47F0",
                    Name = "Main ultranet wallet",
                    AccountColor = Color.FromHex("#6601e3"),
                }

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
            get => new Command<Transaction>(ItemTapped);
        }

        private async void ItemTapped(Transaction Transaction)
        {
            if (Transaction == null) 
                return;
            if (Transaction.Status == TransactionsStatus.Pending)
                await Page.Navigation.PushAsync(new UnfinishTransferPage());
            else
                await TransactionPopup.Show(Transaction);
        }
        public Command OptionsCommand
        {
            get => new Command<Transaction>(Options);
        }

        private async void Options(Transaction Transaction)
        {
            if (Transaction.Status == TransactionsStatus.Pending)
                await Page.Navigation.PushAsync(new UnfinishTransferPage());
            else
                await TransactionPopup.Show(Transaction);
        }
        internal void OnAppearing()
        {
           
        }
        Transaction _SelectedItem ;
        public Transaction SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(ref _SelectedItem, value); }
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
