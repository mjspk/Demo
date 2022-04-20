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
    public partial class SendPage : CustomPage
    {
        SendViewModel viewModel;
        public SendPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new SendViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class SendViewModel : BaseViewModel
    {
       
        public SendViewModel(Page page)
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
      
        public Command TransferCommand
        {
            get => new Command(Transfer);
        }
        private void Transfer()
        {
            if (Position == 1) return;
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
