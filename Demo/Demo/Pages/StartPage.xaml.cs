using Demo.Models;
using Demo.Popups;
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

        private async void ButtonClicked(object sender, EventArgs e)
        {
            switch(Convert.ToInt32((sender as Button).CommandParameter))
            {
                case 0:
                    await Navigation.PushAsync(new AccountDetailsPage(new Wallet
                    {
                        Id = Guid.NewGuid(),
                        Unts = 5005,
                        IconCode = "2T52",
                        Name = "Main ultranet wallet",
                        AccountColor = Color.FromHex("#bb50dd"),

                    }));
                    break;
                case 1:
                    await Navigation.PushAsync(new AuthorsPage());
                    break;
                case 2:
                    await Navigation.PushAsync(new AuthorSearchPage(new Author { BidStatus = BidStatus.None, Name = "amazon.com", ActiveDue = "Active due: 07/07/2022 (in 182 days)" }));
                    break;
                case 19:
                    await Navigation.PushAsync(new AuthorSearchBPage(new Author { BidStatus = BidStatus.None, Name = "amazon.com", ActiveDue = "Active due: 07/07/2022 (in 182 days)" }));
                    break;
                case 20:
                    await Navigation.PushAsync(new AuthorSearchCPage(new Author { BidStatus = BidStatus.None, Name = "amazon.com", ActiveDue = "Active due: 07/07/2022 (in 182 days)" }));
                    break;
                case 3:
                    await Navigation.PushAsync(new AuthorRegistrationPage());
                    break;
                case 4:
                    await Navigation.PushAsync(new AuthorRegistrationRenewalPage());
                    break;
                case 5:
                    await Navigation.PushAsync(new CreateAccountPage());
                    break;
                case 6:
                    await Navigation.PushAsync(new DashboardPage());
                    break;
                case 7:
                    await Navigation.PushAsync(new DeleteAccountPage(new Wallet
                    {
                        Id = Guid.NewGuid(),
                        Unts = 5005,
                        IconCode = "2T52",
                        Name = "Main ultranet wallet",
                        AccountColor = Color.FromHex("#bb50dd"),

                    }));
                    break;
                case 8:
                    await Navigation.PushAsync(new ETHTransferPage());
                    break;
                case 9:
                    await Navigation.PushAsync(new MakeBidPage());
                    break;
                case 10:
                    await Navigation.PushAsync(new ManageAccountsPage());
                    break;
                case 11:
                    await Navigation.PushAsync(new PrivateKeyPage(new Wallet
                    {
                        Id = Guid.NewGuid(),
                        Unts = 5005,
                        IconCode = "2T52",
                        Name = "Main ultranet wallet",
                        AccountColor = Color.FromHex("#bb50dd"),

                    }));
                    break;
                case 12:
                    await Navigation.PushAsync(new ProductSearchPage());
                    break;
                case 13:
                    await Navigation.PushAsync(new ProductsPage());
                    break;
                case 21:
                    await Navigation.PushAsync(new ProductsBPage());
                    break;
                case 14:
                    await Navigation.PushAsync(new RestoreAccountPage());
                    break;
                case 15:
                    await Navigation.PushAsync(new SendPage());
                    break;
                case 16:
                    await Navigation.PushAsync(new TransactionsPage());
                    break;
                case 22:
                    await Navigation.PushAsync(new TransactionsBPage());
                    break;
                case 17:
                    await Navigation.PushAsync(new TransferCompletePage());
                    break;
                case 18:
                    await Navigation.PushAsync(new UnfinishTransferPage());
                    break;
                case 23:
                    await Navigation.PushAsync(new EnterPinPage());
                    break;
                case 24:
                    await Navigation.PushAsync(new EnterPinBPage());
                    break;
                case 25:
                    await CreatePinPopup.Show();
                    break;
                case 26:
                    await Navigation.PushAsync(new NetworkPage());
                    break;
                case 27:
                    await Navigation.PushAsync(new SettingsPage());
                    break;
                case 28:
                    await Navigation.PushAsync(new SettingsBPage());
                    break;
                case 29:
                    await Navigation.PushAsync(new HelpPage());
                    break;
                case 30:
                    await Navigation.PushAsync(new HelpBPage());
                    break;
                case 31:
                    await Navigation.PushAsync(new WhatsNewPage());
                    break;
                case 32:
                    await WhatsNewPopup.Show();
                    break;
                case 33:
                    await NotificationsPopup.Show();
                    break;
                case 34:
                    await NotificationPopup.Show();
                    break;
                case 35:
                    await AccountsPopup.Show();
                    break;
                case 36:
                    await NoNetworkPopup.Show();
                    break;
                case 37:
                    await Navigation.PushAsync(new AboutPage());
                    break;
            }
        }
    }
}