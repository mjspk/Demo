using Demo.Controls;
using Demo.Models;
using Demo.ViewModels;
using Rg.Plugins.Popup.Exceptions;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectAuthorPopup : PopupPage
    {
        private static SelectAuthorPopup popup;
        SelectAuthorViewModel viewModel;
        public SelectAuthorPopup()
        {
            InitializeComponent();
            BindingContext = viewModel= new SelectAuthorViewModel(this);
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public async void Hide()
        {
            await Navigation.RemovePopupPageAsync(popup);
        }
        public static async Task<Author> Show()
        {
            popup = new SelectAuthorPopup();
            await App.Current.MainPage.Navigation.ShowPopupAsDialog(popup);
            return popup.viewModel.SelectedAuthor;
        }


    }
    public class SelectAuthorViewModel : BaseViewModel
    {
        public SelectAuthorViewModel(SelectAuthorPopup popup)
        {
            Popup = popup;
            Authors.Add(new Author { BidStatus = BidStatus.None, Name = "amazon.com", ActiveDue = "Active due: 07/07/2022 (in 182 days)" });
            Authors.Add(new Author { BidStatus = BidStatus.None, Name = "amazon.com", ActiveDue = "Active due: 07/07/2022 (in 182 days)" });
            Authors.Add(new Author { BidStatus = BidStatus.Higher, Name = "Auction A", ActiveDue = "43 days left", CurrentBid = 2435 });
            Authors.Add(new Author { BidStatus = BidStatus.Lower, Name = "Auction A", ActiveDue = "43 days left", CurrentBid = 2435 });
            Authors.Add(new Author { BidStatus = BidStatus.None, Name = "ultranet.org", ActiveDue = "Active due: 07/07/2022 (in 182 days)" });
            Authors.Add(new Author { BidStatus = BidStatus.None, Name = "amazon.com", ActiveDue = "Active due: 07/07/2022 (in 182 days)" });
            Authors.Add(new Author { BidStatus = BidStatus.Higher, Name = "Auction A", ActiveDue = "43 days left", CurrentBid = 2435 });
            Authors.Add(new Author { BidStatus = BidStatus.Lower, Name = "Auction B", ActiveDue = "43 days left", CurrentBid = 2435 });

        }
        public Command CloseCommad
        {
            get => new Command(Close);
        }

        private void Close()
        {
           Popup.Hide();
        }
        CustomCollection<Author> _Authors = new CustomCollection<Author>();
        public Author SelectedAuthor;

        public CustomCollection<Author> Authors
        {
            get { return _Authors; }
            set { SetProperty(ref _Authors, value); }
        }
        public Page Page { get; }
        public Command ItemTppedCommand
        {
            get => new Command<Author>(ItemTpped);
        }
        private void ItemTpped(Author Author)
        {
            SelectedAuthor = Author;
        }
        
        public SelectAuthorPopup Popup { get; }
    }

}