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
    public partial class HelpBPage : CustomPage
    {
        HelpBViewModel viewModel;
        public HelpBPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new HelpBViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class HelpBViewModel : BaseViewModel
    {
       
        public HelpBViewModel(Page page)
        {
            Page = page;
           
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

        public Command TransactionsCommand
        {
            get => new Command(Transactions);
        }

        private async void Transactions()
        {
            await Page.Navigation.PushAsync(new TransactionsPage());
        }
        
        public Page Page { get; }
      
       
    }
}
