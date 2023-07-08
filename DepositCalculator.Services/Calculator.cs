using DepositCalculator.Model;

namespace DepositCalculator.Services
{
  /// <summary>
  /// Compared with this calculator for Annual capitalization https://a2-finance.com/ru/calculators/vse/kalkulyator-slozhnyh-procentov?calc_fields%5Binitial_amount%5D=350000&calc_fields%5Bunit%5D=%E2%82%BD&calc_fields%5Bcontribution_amount%5D=0&calc_fields%5Bfrequency_contributions%5D=1&calc_fields%5Binterest_rate_amount%5D=4.7&calc_fields%5Bcompounded_intervals%5D=1&calc_fields%5Bnumber_years%5D=2#calc
  /// And this formulas for other capitalizations https://www.raiffeisen.ru/wiki/kak-rasschitat-procenty-po-vkladu/
  /// </summary>
  public class Calculator
  {
    private const int DaysInYear = 365;
    private const int MonthesInYear = 12;
    private const int QuartersInYear = 4;
    private const int MonthesInQuarter = 3;

    public double CalcDeposit(CalculationInputData calculationData)
    {
      var absoluteRateOfInterest = calculationData.RateOfInterest / 100;

      DateOnly endDate;
      if (calculationData.DepositPeriodType == DepositPeriod.Years)
      {
        endDate = calculationData.DateOfInvestment.AddYears(calculationData.DepositPeriod);
      }
      else
      {
        endDate = calculationData.DateOfInvestment.AddMonths(calculationData.DepositPeriod);
      }

      var startDate = calculationData.DateOfInvestment;

      double result;
      int days;
      switch (calculationData.Capitalization)
      {
        case TimePeriod.None:
          days = GetDays(startDate, endDate);
          result = CalcWithoutCapitalization(calculationData.TotalInvestment, calculationData.RateOfInterest, days);
          break;
        case TimePeriod.Daily:
          days = GetDays(startDate, endDate); 
          result = CalcCapitalization(calculationData.TotalInvestment, absoluteRateOfInterest, DaysInYear, days);
          break;
        case TimePeriod.Monthly:
          var monthes = GetMonthes(startDate, endDate);
          result = CalcCapitalization(calculationData.TotalInvestment, absoluteRateOfInterest, MonthesInYear, monthes);
          break;
        case TimePeriod.Quarterly:
          var quarters = GetMonthes(startDate, endDate) / MonthesInQuarter;
          if (quarters >= 1)
          {
            result = CalcCapitalization(calculationData.TotalInvestment, absoluteRateOfInterest, QuartersInYear, quarters);
          }
          else
          {
            days = GetDays(startDate, endDate);
            result = CalcWithoutCapitalization(calculationData.TotalInvestment, calculationData.RateOfInterest, days);
          }

          break;
        case TimePeriod.Annual:
          days = GetDays(startDate, endDate);
          var years = days / DaysInYear;
          if (years >= 1)
          {
            result = CalcCapitalization(calculationData.TotalInvestment, absoluteRateOfInterest, 1, years);
          }
          else
          {
            result = CalcWithoutCapitalization(calculationData.TotalInvestment, calculationData.RateOfInterest, days);
          }
          break;
        default:
          result = 0;
          break;
      }

      return Math.Round(result, 2);
    }

    private double CalcWithoutCapitalization(double totalInvestment, double rateOfInterest, int days)
    {
      return totalInvestment + ((totalInvestment * rateOfInterest * days) / DaysInYear) / 100;
    }

    private double CalcCapitalization(double totalInvestment, double absoluteRateOfInterest, int devider, double degree)
    {
      return totalInvestment * Math.Pow(1 + absoluteRateOfInterest / devider, degree);
    }

    private int GetDays(DateOnly startDate, DateOnly endDate)
    {
      return endDate.DayNumber - startDate.DayNumber;
    }


    private int GetMonthes(DateOnly startDate, DateOnly endDate)
    {
      return ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month;
    }
  }
}