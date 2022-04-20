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
    public partial class CreateAccountStepTwoView : ContentView
    {
        public CreateAccountStepTwoView()
        {
            InitializeComponent();
            BindingContext = new CreateAccountViewModel(this);
        }
    }
    public class CreateAccountViewModel : BaseViewModel
    {
        Page Page;
        public CreateAccountViewModel(ContentView view)
        {
            Page = (App.Current.MainPage as NavigationPage).RootPage;
            Colors.Add(new AccountColor { Color = Color.FromHex("#6601e3"), BoderColor = Page.BackgroundColor });
            Colors.Add(new AccountColor { Color = Color.FromHex("#3765f4"), BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#4cb16c"), BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#ba918c"), BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#d56a48"), BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#56d7de"), BoderColor = Color.Transparent });
            Colors.Add(new AccountColor { Color = Color.FromHex("#bb50dd"), BoderColor = Color.Transparent });

            SelectedAccountColor= Colors.First();
        }
        public Command RandomizeCommand
        {
            get => new Command(Randomize);
        }

        private void Randomize()
        {
            ColorTapped(Colors[new Random().Next(0, Colors.Count)]);
        }

        public Command ColorTappedCommand
        {
            get => new Command<AccountColor>(ColorTapped);
        }

        private void ColorTapped(AccountColor obj)
        {

            foreach (var item in Colors)
            {
                item.BoderColor = Color.Transparent;
                Colors.ReportItemChange(item);
            }
            obj.BoderColor = Page.BackgroundColor;
            Colors.ReportItemChange(obj);
            SelectedAccountColor = obj;
        }
       
        CustomCollection<AccountColor> _Colors = new CustomCollection<AccountColor>();
        public CustomCollection<AccountColor> Colors
        {
            get { return _Colors; }
            set { SetProperty(ref _Colors, value); }
        }

        AccountColor _SelectedAccountColor;
        public AccountColor SelectedAccountColor
        {
            get { return _SelectedAccountColor; }
            set { SetProperty(ref _SelectedAccountColor, value); }
        }
      
    }

}