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

namespace Demo.Pages
{
    public partial class AuthorRegistrationCPage : CustomPage
    {
        AuthorRegistrationCViewModel viewModel;
        public AuthorRegistrationCPage(Author Author)
        {
            InitializeComponent();
            BindingContext=viewModel=new AuthorRegistrationCViewModel(this, Author);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class AuthorRegistrationCViewModel : BaseViewModel
    {
       
        public AuthorRegistrationCViewModel(Page page, Author author)
        {
            Page = page;
            Author = author;
        }
        public Command CancelCommand
        {
            get => new Command(Cancel);
        }

        private async void Cancel()
        {
           await Page.Navigation.PopAsync();
        }
        internal void OnAppearing()
        {
           
        }
        public Command MakeBidCommand
        {
            get => new Command(MakeBid);
        }
        private async void MakeBid()
        {
            await Page.Navigation.PushAsync(new MakeBidPage());
        }
        public Command RegisterCommand
        {
            get => new Command(Register);
        }
        private void Register()
        {
            IsRegistered=true;
        }
        bool _IsRegistered;
        public bool IsRegistered
        {
            get => _IsRegistered;
            set { _IsRegistered = value; OnPropertyChanged(); }
        }
        public Page Page { get; }
        public Author Author { get; }
    }
}
