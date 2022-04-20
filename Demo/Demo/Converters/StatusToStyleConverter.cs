using Demo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Demo.Converters
{
    public class StatusToStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((TransactionsStatus)value)
            {
                case TransactionsStatus.Pending:
                    return (Style)App.Current.Resources["Watch"];
                case TransactionsStatus.Sent:
                case TransactionsStatus.Received:
                    return (Style)App.Current.Resources["Done"];
                case TransactionsStatus.Failed:
                    return (Style)App.Current.Resources["Clear"];
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
