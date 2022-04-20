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
    public partial class AuthorTransferStepTwoView : ContentView
    {
        AuthorTransferStepTwoViewModel _viewModel;
        public AuthorTransferStepTwoView()
        {
            InitializeComponent();
            BindingContext= _viewModel= new AuthorTransferStepTwoViewModel();
        }
    }
    public class AuthorTransferStepTwoViewModel : BaseViewModel
    {
        public AuthorTransferStepTwoViewModel()
        {
           
        }
      
    }
}