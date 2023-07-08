using DepositCalculator.Model;
using DepositCalculator.Services;
using System;
using System.Windows.Input;

namespace DepositCalculator.Commands
{
  public class CalculationCommand : ICommand
  {
    private Calculation _calculation;
    private Calculator _calculator;

    public CalculationCommand(Calculation calculation)
    {
      _calculation = calculation;
      _calculator = new Calculator();
    }

    public event EventHandler? CanExecuteChanged;

    public void RaiseCanExecuteChanged()
    {
      if (CanExecuteChanged != null)
        CanExecuteChanged(this, new EventArgs());
    }

    public bool CanExecute(object parameter)
    {
      return _calculation.CalculationInputData.IsValid;
    }

    public void Execute(object parameter)
    {
      _calculation.Result = _calculator.CalcDeposit(_calculation.CalculationInputData);
    }
  }
}
