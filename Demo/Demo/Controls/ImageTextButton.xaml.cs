using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageTextButton : Grid
    {
        public static readonly BindableProperty ImageProperty = BindableProperty.Create("Image", typeof(ImageSource), typeof(ImageTextButton), null);
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(ImageTextButton), null);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create("FontSize", typeof(double), typeof(ImageTextButton), (double)17);
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly BindableProperty ImageHeightProperty = BindableProperty.Create("ImageHeight", typeof(double), typeof(ImageTextButton), (double)17);
        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create("ImageWidth", typeof(double), typeof(ImageTextButton), (double)17);
        public double ImageWidth
        {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(ImageTextButton), Color.Black);
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        public static readonly BindableProperty ImageColorProperty = BindableProperty.Create("ImageColor", typeof(Color), typeof(ImageTextButton), null);
        public Color ImageColor
        {
            get { return (Color)GetValue(ImageColorProperty); }
            set { SetValue(ImageColorProperty, value); }
        }
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(ImageTextButton), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly BindableProperty ImageStyleProperty = BindableProperty.Create("ImageStyle", typeof(Style), typeof(ImageTextButton), null);
        public Style ImageStyle
        {
            get { return (Style)GetValue(ImageStyleProperty); }
            set { SetValue(ImageStyleProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(ImageTextButton), null);
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        private ICommand TransitionCommand
        {
            get
            {
                return new Command( () =>
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

        public ImageTextButton()
        {
            InitializeComponent();
            Initialize();

        }
    }
}