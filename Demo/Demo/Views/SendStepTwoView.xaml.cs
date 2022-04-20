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
    public partial class SendStepTwoView : ContentView
    {
        SendStepTwoViewModel viewModel;
        public SendStepTwoView()
        {
            InitializeComponent();
            BindingContext= viewModel=new SendStepTwoViewModel();   
        }
    }
    public class SendStepTwoViewModel : BaseViewModel
    {
        public SendStepTwoViewModel()
        {
           

        }
        
        public Command SourceTppedCommand
        {
            get => new Command(SourceTpped);
        }
        private void SourceTpped()
        {
          
        }
        public Command RecipientTppedCommand
        {
            get => new Command(RecipientTpped);
        }
        private void RecipientTpped()
        {

        }
       
        Wallet _SourceWallet = new Wallet
        {
            Id = Guid.NewGuid(),
            Unts = 5005,
            IconCode = "47FO",
            Name = "Main ultranet wallet",
            AccountColor = Color.FromHex("#56d7de"),

        };
        public Wallet SourceWallet
        {
            get { return _SourceWallet; }
            set { SetProperty(ref _SourceWallet, value); }
        }
        Wallet _RecipientWallet = new Wallet
        {
            Id = Guid.NewGuid(),
            Unts = 5005,
            IconCode = "47F0",
            Name = "Main ultranet wallet",
            AccountColor = Color.FromHex("#6601e3"),
        };
        public Wallet RecipientWallet
        {
            get { return _RecipientWallet; }
            set { SetProperty(ref _RecipientWallet, value); }
        }
    }

}