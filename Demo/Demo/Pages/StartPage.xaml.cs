using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            switch(Convert.ToInt32((sender as Button).CommandParameter))
            {
                case 0:
                    Navigation.PushAsync(new AccountDetailsPage(new Wallet
                    {
                        Id = Guid.NewGuid(),
                        Unts = 5005,
                        IconCode = "2T52",
                        Name = "Main ultranet wallet",
                        AccountColor = Color.FromHex("#bb50dd"),

                    }));
                    break;
                case 1:
                    Navigation.PushAsync(new AuthorsPage());
                    break;
                case 2:
                    Navigation.PushAsync(new AuthorSearchPage(new Author { BidStatus = BidStatus.None, Name = "amazon.com", ActiveDue = "Active due: 07/07/2022 (in 182 days)" }));
                    break;
                case 19:
                    Navigation.PushAsync(new AuthorSearchBPage(new Author { BidStatus = BidStatus.None, Name = "amazon.com", ActiveDue = "Active due: 07/07/2022 (in 182 days)" }));
                    break;
                case 20:
                    Navigation.PushAsync(new AuthorSearchCPage(new Author { BidStatus = BidStatus.None, Name = "amazon.com", ActiveDue = "Active due: 07/07/2022 (in 182 days)" }));
                    break;
                case 3:
                    Navigation.PushAsync(new AuthorTransferPage());
                    break;
                case 4:
                    Navigation.PushAsync(new AuthorTransferRenewalPage());
                    break;
                case 5:
                    Navigation.PushAsync(new CreateAccountPage());
                    break;
                case 6:
                    Navigation.PushAsync(new DashboardPage());
                    break;
                case 7:
                    Navigation.PushAsync(new DeleteAccountPage(new Wallet
                    {
                        Id = Guid.NewGuid(),
                        Unts = 5005,
                        IconCode = "2T52",
                        Name = "Main ultranet wallet",
                        AccountColor = Color.FromHex("#bb50dd"),

                    }));
                    break;
                case 8:
                    Navigation.PushAsync(new ETHTransferPage());
                    break;
                case 9:
                    Navigation.PushAsync(new MakeBidPage());
                    break;
                case 10:
                    Navigation.PushAsync(new ManageAccountsPage());
                    break;
                case 11:
                    Navigation.PushAsync(new PrivateKeyPage(new Wallet
                    {
                        Id = Guid.NewGuid(),
                        Unts = 5005,
                        IconCode = "2T52",
                        Name = "Main ultranet wallet",
                        AccountColor = Color.FromHex("#bb50dd"),

                    }));
                    break;
                case 12:
                    Navigation.PushAsync(new ProductSearchPage());
                    break;
                case 13:
                    Navigation.PushAsync(new ProductsPage());
                    break;
                case 21:
                    Navigation.PushAsync(new ProductsBPage());
                    break;
                case 14:
                    Navigation.PushAsync(new RestoreAccountPage());
                    break;
                case 15:
                    Navigation.PushAsync(new SendPage());
                    break;
                case 16:
                    Navigation.PushAsync(new TransactionsPage());
                    break;
                case 17:
                    Navigation.PushAsync(new TransferCompletePage());
                    break;
                case 18:
                    Navigation.PushAsync(new UnfinishTransferPage());
                    break;
            }
        }
    }
}