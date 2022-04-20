using Demo.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static Demo.Pages.RestoreAccountViewModel;

namespace Demo.Models
{
    public class Wallet:BindableObject
    {
        public LinearGradientBrush GradientStops(Color color)
        {
            return new LinearGradientBrush(
                new GradientStopCollection
                {
                new GradientStop(color, 0.1f),
                new GradientStop(color.WithSaturation(0.7), 1.0f)
                });
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Unts { get; set; }
        bool _IsSelected;
        public bool IsSelected { get=>_IsSelected; set { _IsSelected = value;OnPropertyChanged(); } }
        public string IconCode { get; set; }
        Color _AccountColor;
        public Color AccountColor { get => _AccountColor; set { _AccountColor = value; Background = GradientStops(value); OnPropertyChanged(); } }
        public LinearGradientBrush Background {set; get; }
    }
}
