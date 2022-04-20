using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPage : ContentPage
    {
        public static readonly BindableProperty LeftContentProperty = BindableProperty.Create("LeftContent", typeof(View), typeof(CustomPage), null);
        public View LeftContent
        {
            get { return (View)GetValue(LeftContentProperty); }
            set { SetValue(LeftContentProperty, value); }
        }
        public static readonly BindableProperty RightContentProperty = BindableProperty.Create("RightContent", typeof(View), typeof(CustomPage), null);
        public View RightContent
        {
            get { return (View)GetValue(RightContentProperty); }
            set { SetValue(RightContentProperty, value); }
        }
        public static readonly BindableProperty BadgeValueProperty = BindableProperty.Create("BadgeValue", typeof(string), typeof(CustomPage), string.Empty);
        public string BadgeValue
        {
            get { return (string)GetValue(BadgeValueProperty); }
            set { SetValue(BadgeValueProperty, value); }
        }

        public static readonly BindableProperty HasBackButtonProperty = BindableProperty.Create("HasBackButton", typeof(bool), typeof(CustomPage), true);
        public bool HasBackButton
        {
            get { return (bool)GetValue(HasBackButtonProperty); }
            set { SetValue(HasBackButtonProperty, value); }
        }
       
        public static readonly BindableProperty AnimationEnabledProperty = BindableProperty.Create("AnimationEnabled", typeof(bool), typeof(CustomPage), false);
        public bool AnimationEnabled
        {
            get { return (bool)GetValue(AnimationEnabledProperty); }
            set { SetValue(AnimationEnabledProperty, value); }
        }
        public static readonly BindableProperty MainContentProperty = BindableProperty.Create("MainContent", typeof(View), typeof(CustomPage), null);
        public View MainContent
        {
            get { return (View)GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }
        public static readonly BindableProperty HeaderProperty = BindableProperty.Create("Header", typeof(View), typeof(CustomPage), null);
        public View Header
        {
            get { return (View)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public static readonly BindableProperty HeaderHeightProperty = BindableProperty.Create("HeaderHeight", typeof(double), typeof(CustomPage),default);
        public double HeaderHeight
        {
            get { return (double)GetValue(HeaderHeightProperty); }
            set { SetValue(HeaderHeightProperty, value); }
        }
        public static readonly BindableProperty IsHeaderVisibleProperty = BindableProperty.Create("HeaderHeight", typeof(bool), typeof(CustomPage), false);
        public bool IsHeaderVisible
        {
            get { return (bool)GetValue(IsHeaderVisibleProperty); }
            set { SetValue(IsHeaderVisibleProperty, value); }
        }
        public static readonly BindableProperty BarItemsProperty = BindableProperty.Create("BarItems", typeof(CustomCollection<ImageButton>), typeof(CustomPage), new CustomCollection<ImageButton>());
        public CustomCollection<ImageButton> BarItems
        {
            get { return (CustomCollection<ImageButton>)GetValue(BarItemsProperty); }
            set { SetValue(BarItemsProperty, value); }
        }
       
        public CustomPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (AnimationEnabled)
            {
                MainFrame.TranslationY = Height;
                await MainFrame.TranslateTo(0, 0, 220, Easing.Linear);
            }
          

        }
        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            if (AnimationEnabled)
                await MainFrame.TranslateTo(0, Height,220 ,Easing.Linear);
        }
        private async void BackButtonclicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

      
    }
}