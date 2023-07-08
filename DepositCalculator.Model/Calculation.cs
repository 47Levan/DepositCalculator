using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DepositCalculator.Model
{
  public class Calculation : INotifyPropertyChanged
  {
    private double _result;

    public Calculation()
    {
      CalculationInputData = new CalculationInputData(); 
    }

    public CalculationInputData CalculationInputData  { get; set; }

    public double Result
    {
      get { return _result; }
      set
      {
        _result = value;
        OnPropertyChanged("Result");
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}