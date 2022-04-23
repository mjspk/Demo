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
    public partial class AuthorRegistrationRenewalStepTwoView : ContentView
    {
        AuthorRegistrationRenewalStepTwoViewModel _viewModel;
        public AuthorRegistrationRenewalStepTwoView()
        {
            InitializeComponent();
            BindingContext= _viewModel= new AuthorRegistrationRenewalStepTwoViewModel();
        }
    }
    public class AuthorRegistrationRenewalStepTwoViewModel : BaseViewModel
    {
        public AuthorRegistrationRenewalStepTwoViewModel()
        {
            

        }
      
       
    }
}