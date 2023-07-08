namespace DepositCalculator.Model
{
  public class CalculationInputData
  {
    public CalculationInputData()
    {
      DateOfInvestment = DateOnly.FromDateTime(DateTime.Now);
    }

    public double TotalInvestment { get; set; }

    public double RateOfInterest { get; set; }

    public Currencies Currency { get; set; }

    public DepositPeriod DepositPeriodType { get; set; }

    public int DepositPeriod { get; set; }

    public DateOnly DateOfInvestment { get; set; }

    public TimePeriod Capitalization { get; set; }

    public bool IsValid => TotalInvestment > 0 && RateOfInterest > 0 && DepositPeriod > 0;
  }
}