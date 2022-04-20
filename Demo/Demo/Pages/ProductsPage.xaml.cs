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
using static Xamarin.Essentials.AppleSignInAuthenticator;

namespace Demo.Pages
{
    public partial class ProductsPage : CustomPage
    {
        ProductsViewModel viewModel;
        public ProductsPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new ProductsViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class ProductsViewModel : BaseViewModel
    {
       
        public ProductsViewModel(Page page)
        {
            Page = page;
            ProductsFilter = new CustomCollection<string> {"All", "To be expired", "Expired", "Hidden", "Shown" };
            Products.Add(new Product {Name = "Ultranet User Center", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Aximion3D", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Ultranet User Center", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "3D UI", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Ultranet User Node", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Aximion3D", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "3D UI", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Ultranet User Node", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Aximion3D", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "3D UI", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Ultranet User Node", Owner = "ultranetorg" });


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
            get => new Command<Product>(ItemTapped);
        }

        private void ItemTapped(Product Product)
        {
            
        }
        public Command OptionsCommand
        {
            get => new Command<Product>(Options);
        }

        private async void Options(Product Product)
        {
           // await AccountOptionsPopup.Show(Product);
        }
        internal void OnAppearing()
        {
           
        }
        Product _SelectedItem ;
        public Product SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(ref _SelectedItem, value); }
        }
        CustomCollection<Product> _Products =new CustomCollection<Product>();
        public CustomCollection<Product>  Products
        {
            get { return _Products; }
            set { SetProperty(ref _Products, value); }
        }
        CustomCollection<string> _ProductsFilter = new CustomCollection<string>();
        public CustomCollection<string> ProductsFilter
        {
            get { return _ProductsFilter; }
            set { SetProperty(ref _ProductsFilter, value); }
        }

        public Page Page { get; }
    }
}
