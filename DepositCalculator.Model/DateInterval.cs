namespace DepositCalculator.Model
{
  public class DateInterval
  {
    public DateInterval(int daysInYear, int days, int mohthes, double quarters) 
    {
      DaysInYear = daysInYear;
      Days = days;
      Monthes = mohthes;
      Quarters = quarters;
    }

    public int DaysInYear { get; set; }

    public int Days { get; set; }

    public int Monthes { get; set; }

    public double Quarters { get; set; }
  }
}