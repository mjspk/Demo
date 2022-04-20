using Demo.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmptyView : ContentView
    {
        public EmptyView()
        {
            InitializeComponent();
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(EmptyView), null);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
    }
}