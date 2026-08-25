using Xunit;

public class PayrollTests
{
    [Fact]
    public void CalculateNetPay_ReturnsCorrectValue()
    {
        Payroll payroll = new Payroll(38, 42.5m, 0.2m);

        decimal result = payroll.CalculateNetPay();

        Assert.Equal(1292.00m, result);
    }

    [Fact]
    public void ChangeTaxRate_ChangesNetPay()
    {
        Payroll payroll = new Payroll(38, 42.5m, 0.2m);

        payroll.ChangeTaxRate(0.25m);

        Assert.Equal(1211.25m, payroll.CalculateNetPay());
    }

    [Fact]
    public void NegativeHours_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Payroll payroll = new Payroll(-1, 42.5m, 0.2m);
        });
    }

    [Fact]
    public void NegativeRate_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Payroll payroll = new Payroll(38, -42.5m, 0.2m);
        });
    }

    [Fact]
    public void NegativeTaxRate_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Payroll payroll = new Payroll(38, 42.5m, -0.2m);
        });
    }

    [Fact]
    public void ChangeTaxRate_NegativeValue_ThrowsException()
    {
        Payroll payroll = new Payroll(38, 42.5m, 0.2m);

        Assert.Throws<ArgumentException>(() =>
        {
            payroll.ChangeTaxRate(-0.1m);
        });
    }
 [Fact]
public void Properties_ReturnCorrectValues()
{
    Payroll payroll = new Payroll(38, 42.5m, 0.2m);

    Assert.Equal(38, payroll.Hours);
    Assert.Equal(42.5m, payroll.Rate);
    Assert.Equal(0.2m, payroll.TaxRate);
}
}