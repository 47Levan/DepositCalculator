using DepositCalculator.Model;
using DepositCalculator.Services;

namespace DepositCalculator.Test
{
  public class DepositCalculatorTests
  {
    private Calculator _calculator;
    private DateOnly _startOfYear;
    private CalculationInputData _inputData;

    [SetUp]
    public void Setup()
    {
      _calculator = new Calculator();

      var now = DateOnly.FromDateTime(DateTime.Now);
      _startOfYear = new DateOnly(now.Year, 1, 1);
      _inputData = new CalculationInputData()
      {
        TotalInvestment = 350000,
        DateOfInvestment = _startOfYear,
        RateOfInterest = 4.7,
        Currency = Currencies.Hryvnia,
      };
    }

    [Test]
    public void NoIndexation()
    {
      // Arrange
      _inputData.Capitalization = TimePeriod.None;
      _inputData.DepositPeriodType = DepositPeriod.Monthes;
      _inputData.DepositPeriod = 9;

      // Act
      var result = _calculator.CalcDeposit(_inputData);

      //Assert
      Assert.That(result, Is.EqualTo(362303.7));
    }

    [Test]
    public void DailyIndexation()
    {
      // Arrange
      _inputData.Capitalization = TimePeriod.Daily;
      _inputData.DepositPeriodType = DepositPeriod.Monthes;
      _inputData.DepositPeriod = 9;

      // Act
      var result = _calculator.CalcDeposit(_inputData);

      //Assert
      Assert.That(result, Is.EqualTo(362521.69));
    }

    [Test]
    public void MonthlyIndexation()
    {
      // Arrange
      _inputData.Capitalization = TimePeriod.Monthly;
      _inputData.DepositPeriodType = DepositPeriod.Monthes;
      _inputData.DepositPeriod = 9;

      // Act
      var result = _calculator.CalcDeposit(_inputData);

      //Assert
      Assert.That(result, Is.EqualTo(362532.56));
    }

    [Test]
    public void QuarterlyIndexation()
    {
      // Arrange
      _inputData.Capitalization = TimePeriod.Quarterly;
      _inputData.DepositPeriodType = DepositPeriod.Monthes;
      _inputData.DepositPeriod = 9;

      // Act
      var result = _calculator.CalcDeposit(_inputData);

      //Assert
      Assert.That(result, Is.EqualTo(362483.03));
    }

    [Test]
    public void AnnualIndexation()
    {
      // Arrange
      _inputData.Capitalization = TimePeriod.Annual;
      _inputData.DepositPeriodType = DepositPeriod.Years;
      _inputData.DepositPeriod = 2;

      // Act
      var result = _calculator.CalcDeposit(_inputData);

      //Assert
      Assert.That(result, Is.EqualTo(383673.15));
    }
  }
}