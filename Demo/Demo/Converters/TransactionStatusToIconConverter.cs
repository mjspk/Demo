using Demo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Demo.Converters
{
    public class TransactionStatusToIconConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((TransactionsStatus)value)
            {
                case TransactionsStatus.Pending:
                    return new FontImageSource { Color = Settings.Purple, Size = 30, Glyph = IconFont.Accounts, FontFamily = "icomoon" };
                case TransactionsStatus.Received:
                    return new FontImageSource { Color = Settings.Green, Size = 30, Glyph = IconFont.Receive, FontFamily = "icomoon" };
                case TransactionsStatus.Sent:
                    return new FontImageSource { Color = Settings.Blue, Size = 30, Glyph = IconFont.Send, FontFamily = "icomoon" };
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
