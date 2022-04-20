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
    public partial class AuthorsPage : CustomPage
    {
        AuthorsViewModel viewModel;
        public AuthorsPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new AuthorsViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }

       

        private async void TransferAuthorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuthorTransferPage());
        }

        private async void MackBidClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MakeBidPage());
        }
    }
    public class AuthorsViewModel : BaseViewModel
    {
       
        public AuthorsViewModel(Page page)
        {
            Page = page;
            AuthorsFilter = new CustomCollection<string> {"All", "To be expired", "Expired", "Hidden", "Shown" };
            Authors.Add(new Author { BidStatus = BidStatus.None, Name = "amazon.com", ActiveDue = "Active due: 07/07/2022 (in 182 days)" });
            Authors.Add(new Author { BidStatus = BidStatus.None,Name= "amazon.com" , ActiveDue= "Active due: 07/07/2022 (in 182 days)" });
            Authors.Add(new Author { BidStatus = BidStatus.Higher, Name = "Auction A", ActiveDue = "43 days left", CurrentBid=2435});
            Authors.Add(new Author { BidStatus = BidStatus.Lower, Name = "Auction A", ActiveDue = "43 days left", CurrentBid = 2435 });
            Authors.Add(new Author { BidStatus = BidStatus.None, Name = "ultranet.org", ActiveDue = "Active due: 07/07/2022 (in 182 days)" });
            Authors.Add(new Author { BidStatus = BidStatus.None, Name = "amazon.com", ActiveDue = "Active due: 07/07/2022 (in 182 days)" });
            Authors.Add(new Author { BidStatus = BidStatus.Higher, Name = "Auction A", ActiveDue = "43 days left", CurrentBid = 2435 });
            Authors.Add(new Author { BidStatus = BidStatus.Lower, Name = "Auction B", ActiveDue = "43 days left", CurrentBid = 2435 });


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
            get => new Command<Author>(ItemTapped);
        }

        private async void ItemTapped(Author Author)
        {
            if (Author == null) 
                return;
            await Page.Navigation.PushAsync(new AuthorRegistrationPage(Author));
        }
        public Command OptionsCommand
        {
            get => new Command<Author>(Options);
        }

        private async void Options(Author Author)
        {
           // await AccountOptionsPopup.Show(Author);
        }
        internal void OnAppearing()
        {
           
        }
        Author _SelectedItem ;
        public Author SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(ref _SelectedItem, value); }
        }
        CustomCollection<Author> _Authors =new CustomCollection<Author>();
        public CustomCollection<Author>  Authors
        {
            get { return _Authors; }
            set { SetProperty(ref _Authors, value); }
        }
        CustomCollection<string> _AuthorsFilter = new CustomCollection<string>();
        public CustomCollection<string> AuthorsFilter
        {
            get { return _AuthorsFilter; }
            set { SetProperty(ref _AuthorsFilter, value); }
        }

        public Page Page { get; }
    }
}
