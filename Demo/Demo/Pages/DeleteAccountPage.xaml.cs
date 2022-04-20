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
using static Xamarin.Forms.Button.ButtonContentLayout;
using static Xamarin.Forms.Button;

namespace Demo.Pages
{
    public partial class DeleteAccountPage : CustomPage
    {
        DeleteAccountViewModel viewModel;
        public DeleteAccountPage(Wallet wallet)
        {
            InitializeComponent();
            BindingContext=viewModel=new DeleteAccountViewModel(this,wallet);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class DeleteAccountViewModel : BaseViewModel
    {
       
        public DeleteAccountViewModel(Page page, Wallet wallet)
        {
            Page = page;
            Wallet = wallet;          
            Authors.Add(new Author { Name = "ultranet" });
            Authors.Add(new Author { Name = "ultranetorganization" });
            Authors.Add(new Author { Name = "aximion" });
            Products.Add(new Product { Name = "UNS" });
            Products.Add(new Product { Name = "Aximion3D" });
            Products.Add(new Product { Name = "ultranet" });
           

        }
        public Command DeleteCommand
        {
            get => new Command(Delete);
        }

        private async void Delete()
        {
           await DeleteAccountPopup.Show(Wallet);
        }
        internal void OnAppearing()
        {
           
        }
       
        CustomCollection<Author> _Authors = new CustomCollection<Author>();
        public CustomCollection<Author> Authors
        {
            get { return _Authors; }
            set { SetProperty(ref _Authors, value); }
        }
        CustomCollection<Product> _Products = new CustomCollection<Product>();
        public CustomCollection<Product> Products
        {
            get { return _Products; }
            set { SetProperty(ref _Products, value); }
        }


        public Page Page { get; }
        Wallet _Wallet;
        public Wallet Wallet
        {
            get { return _Wallet; }
            set { SetProperty(ref _Wallet, value); }
        }
       
    }
}
