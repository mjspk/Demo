using Demo.Controls;
using Demo.Helpers;
using Demo.Models;
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
    public partial class ETHTransferPage : CustomPage
    {
        ETHTransferViewModel viewModel;
        public ETHTransferPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new ETHTransferViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class ETHTransferViewModel : BaseViewModel
    {
       
        public ETHTransferViewModel(Page page)
        {
            Page = page;
        }
       
        public Command CloseCommad
        {
            get => new Command(Close);
        }

        private async void Close()
        {
            await Page.Navigation.PopModalAsync();
        }
        public Command ConfirmCommand
        {
            get => new Command(Confirm);
        }
        private async void Confirm()
        {
            await Page.Navigation.PushAsync(new TransferCompletePage());
        }
        public Command PrevCommad
        {
            get => new Command(Prev);
        }
        private void Prev()
        {
            Position -= 1;
        }
        public Command NextCommad
        {
            get => new Command(Next);
        }
        private void Next()
        {
            if (Position == 2) return;
            Position += 1;
        }
       
        internal void OnAppearing()
        {
           
        }
     
        public Page Page { get; }
      
        int _Position;
        public int Position
        {
            get { return _Position; }
            set { SetProperty(ref _Position, value); }
        }
      
    }
}
