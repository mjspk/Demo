using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwitchView : ContentView
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadius", typeof(double), typeof(SwitchView), default);
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static BindableProperty CurrentColorProperty = BindableProperty.Create(nameof(CurrentColor), typeof(Color), typeof(SwitchView), Color.Gray);
        public Color CurrentColor
        {
            get { return (Color)GetValue(CurrentColorProperty); }
            set { SetValue(CurrentColorProperty, value); }
        }
        public static BindableProperty OffColorProperty = BindableProperty.Create(nameof(OffColor), typeof(Color), typeof(SwitchView), Color.Gray);
        public Color OffColor
        {
            get { return (Color)GetValue(OffColorProperty); }
            set { SetValue(OffColorProperty, value); }
        }
        public static BindableProperty OnColorProperty = BindableProperty.Create(nameof(OnColor), typeof(Color), typeof(SwitchView), Color.Blue);
        public Color OnColor
        {
            get { return (Color)GetValue(OnColorProperty); }
            set { SetValue(OnColorProperty, value); }
        }
        public static readonly BindableProperty IsOnProperty = BindableProperty.Create("IsOn", typeof(bool), typeof(SwitchView), true);
        public bool IsOn
        {
            get { return (bool)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }

        private bool JustSet=true;
        private bool IsRunning;
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(SwitchView), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
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
                            Command.Execute(IsOn);
                        }
                    }
                    catch
                    {

                    }
                });
            }
        }



        public event EventHandler Tapped;
        public void Initialize()
        {
            CurrentColor = OffColor;
            var tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.Command = TransitionCommand;
            GestureRecognizers.Add(tap);

        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Switch();
            Tapped?.Invoke(sender, e);
        }
        
        public async void Switch()
        {
            if (IsRunning) return;
            IsRunning = true;
            if (IsOn && !JustSet)
            {
                await thumb.TranslateTo(thumb.TranslationX-thumb.Width, 0);
                CurrentColor = OffColor;
            }
            else if (!IsOn)
            {
                await thumb.TranslateTo(thumb.Width, 0);
                CurrentColor = OnColor;
            }
            IsOn = !IsOn;
            IsRunning=JustSet = false;
        }
        public SwitchView()
        {
            InitializeComponent();
            Initialize();
        }

        private void instance_SizeChanged(object sender, EventArgs e)
        {
            if (frame.Width > 0)
            {
                frame.WidthRequest = frame.Height * 2;
                thumb.HeightRequest=thumb.WidthRequest = frame.Height-4;
                thumb.HorizontalOptions = LayoutOptions.StartAndExpand;
                Switch();
            }

        }
    }
}