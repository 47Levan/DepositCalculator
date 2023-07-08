using System;
using System.Globalization;
using System.Windows.Data;

namespace DepositCalculator.Converters
{
  public class IntToStringConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      int amount = (int)value;
      return amount.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string text = (string)value;
      int price;
      if (!int.TryParse(text, out price))
      {
        return 0;
      }

      return price;
    }
  }
}