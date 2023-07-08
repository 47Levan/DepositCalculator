using DepositCalculator.Model;

namespace DepositCalculator.ViewModel
{

  public class CalculationViewModel
  {
    public CalculationViewModel()
    {
      CalculationData = new CalculationData();
    }

    public CalculationData CalculationData { get; set; }
  }
}