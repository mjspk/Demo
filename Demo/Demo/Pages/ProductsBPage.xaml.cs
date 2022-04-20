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
    public partial class ProductsBPage : CustomPage
    {
        ProductsBViewModel viewModel;
        public ProductsBPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new ProductsBViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class ProductsBViewModel : BaseViewModel
    {
       
        public ProductsBViewModel(Page page)
        {
            Page = page;
            ProductsFilter = new CustomCollection<string> {"All", "To be expired", "Expired", "Hidden", "Shown" };
            Products.Add(new Product {Name = "Ultranet User Center", Color = Color.FromHex("#4900E3"), Initl ="U", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Aximion3D",Color=Color.FromHex("#18C6A6"), Initl = "A", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "3D UI", Color = Color.FromHex("#EE7636"), Initl = "3", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Ultranet User Node", Color = Color.FromHex("#4900E3"), Initl = "U", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Aximion3D", Color = Color.FromHex("#18C6A6"), Initl = "A", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "3D UI", Color = Color.FromHex("#EE7636"), Initl = "3", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Ultranet User Node", Color = Color.FromHex("#4900E3"), Initl = "U", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Aximion3D", Color = Color.FromHex("#18C6A6"), Initl = "A", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "3D UI", Color = Color.FromHex("#EE7636"), Initl = "3", Owner = "ultranetorg" });
            Products.Add(new Product { Name = "Ultranet User Node", Color = Color.FromHex("#4900E3"), Initl = "U", Owner = "ultranetorg" });
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
