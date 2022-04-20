using Demo.Controls;
using Demo.Models;
using Demo.Popups;
using Demo.ViewModels;
using System;
using Xamarin.Forms;

namespace Demo.Pages
{
    public partial class ProductSearchPage : CustomPage
    {
        ProductSearchViewModel viewModel;
        public ProductSearchPage()
        {
            InitializeComponent();
            BindingContext=viewModel=new ProductSearchViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
    public class ProductSearchViewModel : BaseViewModel
    {
       
        public ProductSearchViewModel(Page page)
        {
            ProductsFilter = new CustomCollection<string> { "Recent", "By author" };
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Products.Add(new Product { Name = "Edge Browser", Owner = "microsoft" });
            Products.Add(new Product { Name = "Amazon Helmet", Owner = "Amazon" });
            Products.Add(new Product { Name = "Chrome", Owner = "Google" });
            Page = page;
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
            get => new Command<Transaction>(ItemTapped);
        }

        private async void ItemTapped(Transaction Transaction)
        {
            if (Transaction == null) 
                return;
            if (Transaction.Status == TransactionsStatus.Pending)
                await Page.Navigation.PushAsync(new UnfinishTransferPage());
            else
                await TransactionPopup.Show(Transaction);
        }
        public Command OptionsCommand
        {
            get => new Command<Transaction>(Options);
        }

        private async void Options(Transaction Transaction)
        {
            if (Transaction.Status == TransactionsStatus.Pending)
                await Page.Navigation.PushAsync(new UnfinishTransferPage());
            else
                await TransactionPopup.Show(Transaction);
        }
        internal void OnAppearing()
        {
           
        }
        CustomCollection<Product> _Products = new CustomCollection<Product>();
        public CustomCollection<Product> Products
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
