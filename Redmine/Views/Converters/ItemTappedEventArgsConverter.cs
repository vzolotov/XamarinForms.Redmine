using System;
using System.Globalization;
using Xamarin.Forms;

namespace Redmine.Views.Converters
{
    public class ItemTappedEventArgsConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var arg = value as ItemTappedEventArgs;
            return arg.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}