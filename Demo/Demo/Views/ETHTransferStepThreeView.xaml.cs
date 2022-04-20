using Demo.Controls;
using Demo.Models;
using Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ETHTransferStepThreeView : ContentView
    {
        ETHTransferStepThreeViewModel _viewModel;
        public ETHTransferStepThreeView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ETHTransferStepThreeViewModel();
        }
    }
    public class ETHTransferStepThreeViewModel : BaseViewModel
    {
        public ETHTransferStepThreeViewModel()
        {
        }
        Wallet _Wallet = new Wallet
        {
            Id = Guid.NewGuid(),
            Unts = 5005,
            IconCode = "47F0",
            Name = "Main ultranet wallet",
            AccountColor = Color.FromHex("#6601e3"),
        };
        public Wallet Wallet
        {
            get { return _Wallet; }
            set { SetProperty(ref _Wallet, value); }
        }

    }

}