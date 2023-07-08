using DepositCalculator.Commands;
using DepositCalculator.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DepositCalculator.ViewModels
{

  public class CalculationViewModel : INotifyPropertyChanged
  {
    public CalculationViewModel()
    {
      Calculation = new Calculation();
      CalculationCommand = new CalculationCommand(Calculation);
    }

    public Calculation Calculation { get; set; }

    public CalculationCommand CalculationCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    public void RaiseCanExecuteChanged()
    {
      CalculationCommand.RaiseCanExecuteChanged();
    }
  }
}