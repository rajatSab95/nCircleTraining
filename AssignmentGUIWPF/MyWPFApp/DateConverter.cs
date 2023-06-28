using System;
using System.Windows.Data;
namespace MyWPFApp{

public class DateTimeConverter : IValueConverter
{
    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value != null)
        {
            DateTime test = (DateTime) value ;
            string date = test.ToString("d/M/yyyy");
            return (date);
        }
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    #endregion
}
}