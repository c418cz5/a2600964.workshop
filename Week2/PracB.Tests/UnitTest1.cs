using Xunit;

public class BankAccountTests
{
    [Fact]
    public void Properties_ReturnCorrectValues()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        Assert.Equal("Alex", account.Owner);
        Assert.Equal(1000m, account.Balance);
    }

    [Fact]
    public void DepositDecimal_IncreasesBalance()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        account.Deposit(100.5m);

        Assert.Equal(1100.5m, account.Balance);
    }

    [Fact]
    public void DepositInt_IncreasesBalance()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        account.Deposit(100);

        Assert.Equal(1100m, account.Balance);
    }

    [Fact]
    public void DepositDouble_IncreasesBalance()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        account.Deposit(50.5);

        Assert.Equal(1050.5m, account.Balance);
    }

    [Fact]
    public void DepositDecimal_ThrowsForInvalidAmount()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        Assert.Throws<ArgumentException>(() =>
        {
            account.Deposit(-1m);
        });
    }

    [Fact]
    public void DepositInt_ThrowsForInvalidAmount()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        Assert.Throws<ArgumentException>(() =>
        {
            account.Deposit(-1);
        });
    }

    [Fact]
    public void DepositDouble_ThrowsForInvalidAmount()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        Assert.Throws<ArgumentException>(() =>
        {
            account.Deposit(-1.5);
        });
    }

    [Fact]
    public void Withdraw_ReducesBalance()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        account.Withdraw(200m);

        Assert.Equal(800m, account.Balance);
    }

    [Fact]
    public void Withdraw_ThrowsForInvalidAmount()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        Assert.Throws<ArgumentException>(() =>
        {
            account.Withdraw(-1m);
        });
    }

    [Fact]
    public void Withdraw_ThrowsWhenBalanceIsTooLow()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        Assert.Throws<InvalidOperationException>(() =>
        {
            account.Withdraw(1500m);
        });
    }
}
