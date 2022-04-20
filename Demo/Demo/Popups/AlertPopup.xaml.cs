using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace Demo.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlertPopup : PopupPage
    {
       
        public AlertPopup(string message)
        {
            InitializeComponent();
            Message = message;
            BindingContext = this;
        }
        public bool Result;
        private static AlertPopup popup;

        public string Message { get; }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        public async void Hide()
        {
            await Navigation.RemovePopupPageAsync(this);
        }
        public static async Task Show(string message)
        {
            popup = new AlertPopup(message);
            await App.Current.MainPage.Navigation.ShowPopupAsDialog(popup);
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            Hide();
        }

       
    }
    
}