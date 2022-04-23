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
    public partial class NotificationPopup : PopupPage
    {
        private static NotificationPopup popup;
        NotificationViewModel viewModel;
        public NotificationPopup()
        {
            InitializeComponent();
           BindingContext=viewModel=new NotificationViewModel();
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
            popup = new NotificationPopup();
            await App.Current.MainPage.Navigation.ShowPopupAsDialog(popup);
        }


    }
    public class NotificationViewModel : BaseViewModel
    {
        public NotificationViewModel()
        {
            
        }
        Notification _Notification= new Notification
        {
            Title = "Today at 16:00",
            Body = "Your application P2P Browser version 1.12.2 successfully deployed to Ultranet network",
            Type = NotificationType.ProductOperations,
            Severity = Severity.High
        };
        public Notification Notification
        {
            get { return _Notification; }
            set { SetProperty(ref _Notification, value); }
        }
    }

}