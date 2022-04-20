using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MianPageButton : Frame
    {
        public static readonly BindableProperty ImageProperty = BindableProperty.Create("Image", typeof(ImageSource), typeof(MianPageButton), null);
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(MianPageButton), null);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly BindableProperty DetailsProperty = BindableProperty.Create("Details", typeof(string), typeof(MianPageButton), null);
        public string Details
        {
            get { return (string)GetValue(DetailsProperty); }
            set { SetValue(DetailsProperty, value); }
        }
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(MianPageButton), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(MianPageButton), null);
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        private ICommand TransitionCommand
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                       
                        if (Command != null)
                        {
                            Command.Execute(CommandParameter);
                        }
                    }
                    catch
                    {

                    }
                });
            }
        }

       

        public event EventHandler Clicked;
        public void Initialize()
        {

            var tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.Command = TransitionCommand;
            GestureRecognizers.Add(tap);

        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Clicked?.Invoke(sender, e);
        }

        public MianPageButton()
        {
            InitializeComponent();
            Initialize();

        }
    }
}