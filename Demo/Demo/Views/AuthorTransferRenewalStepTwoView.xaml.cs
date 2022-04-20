using Demo.Controls;
using Demo.Models;
using Demo.Popups;
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
    public partial class AuthorTransferRenewalStepTwoView : ContentView
    {
        AuthorTransferRenewalStepTwoViewModel _viewModel;
        public AuthorTransferRenewalStepTwoView()
        {
            InitializeComponent();
            BindingContext= _viewModel= new AuthorTransferRenewalStepTwoViewModel();
        }
    }
    public class AuthorTransferRenewalStepTwoViewModel : BaseViewModel
    {
        public AuthorTransferRenewalStepTwoViewModel()
        {
            

        }
      
       
    }
}