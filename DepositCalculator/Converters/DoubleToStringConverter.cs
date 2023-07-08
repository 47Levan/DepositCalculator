using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DepositCalculator.Converters
{

  public class DoubleToStringConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      double amount = (double)value;
      return amount.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string text = (string)value;
      double price;
      if (!double.TryParse(text, out price))
      {
        return 0;
      }

      return price;
    }
  }
}