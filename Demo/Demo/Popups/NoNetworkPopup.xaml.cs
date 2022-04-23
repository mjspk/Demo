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
    public partial class NoNetworkPopup : PopupPage
    {
        private static NoNetworkPopup popup;
        public NoNetworkPopup()
        {
            InitializeComponent();
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
            popup = new NoNetworkPopup();
            await App.Current.MainPage.Navigation.ShowPopupAsDialog(popup);
        }


    }

}