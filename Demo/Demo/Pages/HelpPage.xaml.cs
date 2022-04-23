using Demo.Controls;
using Demo.Models;
using Demo.Popups;
using Demo.ViewModels;
using System;
using Xamarin.Forms;

namespace Demo.Pages
{
    public partial class HelpPage : CustomPage
    {
        HelpViewModel viewModel;
        public HelpPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new HelpViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class HelpViewModel : BaseViewModel
    {
       
        public HelpViewModel(Page page)
        {
            
            Page = page;
            Helps.Add("How to turn animation on or off in the search bar");
            Helps.Add("How to quickly change Android phone settings");
            Helps.Add("How to understand which settings the icons correspond to the following icons are located in the upper right corner of the screen or in the quick settings panel");
            Helps.Add("The quick settings panel makes it easy to navigate and customize options");
            Helps.Add("How to turn animation on or off in the search bar");
            Helps.Add("How to quickly change Android phone settings");
            Helps.Add("How to understand which settings the icons correspond to the following icons are located in the upper right corner of the screen or in the quick settings panel");
            Helps.Add("The quick settings panel makes it easy to navigate and customize options");
            Helps.Add("How to turn animation on or off in the search bar");
            Helps.Add("How to quickly change Android phone settings");
            Helps.Add("How to understand which settings the icons correspond to the following icons are located in the upper right corner of the screen or in the quick settings panel");
            Helps.Add("The quick settings panel makes it easy to navigate and customize options");
            Helps.Add("How to turn animation on or off in the search bar");

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
            get => new Command<string>(ItemTapped);
        }

        private async void ItemTapped(string help)
        {
            
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
        CustomCollection<string> _Helps = new CustomCollection<string>();
        public CustomCollection<string> Helps
        {
            get { return _Helps; }
            set { SetProperty(ref _Helps, value); }
        }

        public Page Page { get; }
    }
}
