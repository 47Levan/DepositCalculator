using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DepositCalculator.Model;
using DepositCalculator.ViewModels;

namespace DepositCalculator
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public CalculationViewModel CalculationViewModel { get; set; }

    public MainWindow()
    {
      InitializeComponent();
      CalculationViewModel = new CalculationViewModel();
      DataContext = CalculationViewModel;

      currenciesCombobox.ItemsSource = Enum.GetValues(typeof(Currencies)).Cast<Currencies>();
      timePeriodsCombobox.ItemsSource = Enum.GetValues(typeof(DepositPeriod)).Cast<DepositPeriod>();
      capitalizationCombobox.ItemsSource = Enum.GetValues(typeof(TimePeriod)).Cast<TimePeriod>();
    }

    private void TextBox_ValidatePositiveNumber(object sender, TextCompositionEventArgs e)
    {
      var textBox = (TextBox)sender;
      var totalText = textBox.Text + e.Text;
      e.Handled = !Regex.IsMatch(totalText, @"^\d+(\.\d{0,2})?$");
    }


    private void TextBox_ValidatePositiveNumberInt(object sender, TextCompositionEventArgs e)
    {
      var textBox = (TextBox)sender;
      var totalText = textBox.Text + e.Text;
      e.Handled = !Regex.IsMatch(totalText, @"^[1-9]\d*$");
    }

    private void TextBox_ValidatePercent(object sender, TextCompositionEventArgs e)
    {
      var textBox = (TextBox)sender;
      var totalText = textBox.Text + e.Text;
      e.Handled = !Regex.IsMatch(totalText, "^(?:100(?:\\.00)?|\\d{1,2}(?:\\.\\d{0,2})?)$");
    }

    private void TextBox_RequiredDataTextChanged(object sender, TextChangedEventArgs e)
    {
      CalculationViewModel.RaiseCanExecuteChanged();
      e.Handled = true;
    }
  }
}
