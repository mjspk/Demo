using Demo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Demo.Converters
{
    public class NotificationTypeConverter : IValueConverter
    {
        

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((NotificationType)value)
            {
                case NotificationType.ProductOperations:
                    return new FontImageSource
                    {
                        FontFamily= "icomoon",
                        Size=40,
                        Color=Color.FromHex("#E03030"),
                        Glyph= IconFont.ProductOperations
                    };
                case NotificationType.SystemEvent:
                    return new FontImageSource
                    {
                        FontFamily = "icomoon",
                        Size = 40,
                        Color = Color.FromHex("#E09A30"),
                        Glyph = IconFont.SystemEvent
                    };
                case NotificationType.AuthorOperations:
                    return new FontImageSource
                    {
                        FontFamily = "icomoon",
                        Size = 40,
                        Color = Color.FromHex("#53E030"),
                        Glyph = IconFont.AuthorOperations
                    };
                case NotificationType.TokenOperations:
                    return new FontImageSource
                    {
                        FontFamily = "icomoon",
                        Size = 40,
                        Color = Color.FromHex("#E03030"),
                        Glyph = IconFont.ProductOperations
                    };
                case NotificationType.Server:
                    return new FontImageSource
                    {
                        FontFamily = "icomoon",
                        Size = 40,
                        Color = Color.FromHex("#53E030"),
                        Glyph = IconFont.Server
                    };
                case NotificationType.Wallet:
                    return new FontImageSource
                    {
                        FontFamily = "icomoon",
                        Size = 40,
                        Color = Color.FromHex("#53E030"),
                        Glyph = IconFont.Wallet
                    };
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
