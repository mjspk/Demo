using Demo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Demo.Converters
{
    public class IconTintConverter : IValueConverter
    {
        Button btn;
        private FontImageSource source;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            btn= (Button)parameter;
            if (btn != null)
            {
                source = btn.ImageSource as FontImageSource;
                source.Color = btn.TextColor;
                return source;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
