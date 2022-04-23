using Demo.Controls;
using Demo.Models;
using Demo.ViewModels;
using Rg.Plugins.Popup.Exceptions;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPopup : PopupPage
    {
        private static NotificationsPopup popup;
        NotificationsViewModel viewModel;
        public NotificationsPopup()
        {
            InitializeComponent();
           BindingContext=viewModel=new NotificationsViewModel();
        }
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public async void Hide()
        {
            await Navigation.RemovePopupPageAsync(popup);
        }
        public static async Task Show()
        {
            popup = new NotificationsPopup();
            await App.Current.MainPage.Navigation.ShowPopupAsDialog(popup);
        }


    }
    public class NotificationsViewModel : BaseViewModel
    {
        public NotificationsViewModel()
        {
            Notifications.Add(new Notification
            {
                Title= "Today at 16:00",
                Body= "Your application P2P Browser version 1.12.2 successfully deployed to Ultranet network",
                Type= NotificationType.ProductOperations,
                Severity = Severity.High
            });
            Notifications.Add(new Notification
            {
                Title = "Today at 16:00",
                Body = "Your application P2P Browser version 1.12.2 successfully deployed to Ultranet network",
                Type = NotificationType.SystemEvent,
                Severity = Severity.Low
            });
            Notifications.Add(new Notification
            {
                Title = "Today at 16:00",
                Body = "Your application P2P Browser version 1.12.2 successfully deployed to Ultranet network",
                Type = NotificationType.AuthorOperations,
                Severity = Severity.Mid
            });
            Notifications.Add(new Notification
            {
                Title = "Today at 16:00",
                Body = "Your application P2P Browser version 1.12.2 successfully deployed to Ultranet network",
                Type = NotificationType.TokenOperations,
                Severity = Severity.High
            });
            Notifications.Add(new Notification
            {
                Title = "Today at 16:00",
                Body = "Your application P2P Browser version 1.12.2 successfully deployed to Ultranet network",
                Type = NotificationType.Server,
                Severity = Severity.Low
            });
            Notifications.Add(new Notification
            {
                Title = "Today at 16:00",
                Body = "Your application P2P Browser version 1.12.2 successfully deployed to Ultranet network",
                Type = NotificationType.Wallet,
                Severity = Severity.Mid
            });
            Notifications.Add(new Notification
            {
                Title = "Today at 16:00",
                Body = "Your application P2P Browser version 1.12.2 successfully deployed to Ultranet network",
                Type = NotificationType.Server,
                Severity= Severity.High
            });
        }
        CustomCollection<Notification> _Notifications = new CustomCollection<Notification>();
        public CustomCollection<Notification> Notifications
        {
            get { return _Notifications; }
            set { SetProperty(ref _Notifications, value); }
        }
    }

}