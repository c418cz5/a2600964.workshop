using System;
using System.IO;
using Xunit;

public class AccountTests
{
    [Fact]
    public void BankAccount_ReturnsCorrectValues()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        Assert.Equal("Alex", account.Owner);
        Assert.Equal(1000m, account.Balance);
    }

    [Fact]
    public void BankAccount_RejectsNegativeBalance()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            BankAccount account = new BankAccount("Alex", -1m);
        });
    }

    [Fact]
    public void Deposit_AddsDecimalAmount()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        account.Deposit(100.5m);

        Assert.Equal(1100.5m, account.Balance);
    }

    [Fact]
    public void Deposit_AddsIntAmount()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        account.Deposit(100);

        Assert.Equal(1100m, account.Balance);
    }

    [Fact]
    public void Deposit_AddsDoubleAmount()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        account.Deposit(50.5);

        Assert.Equal(1050.5m, account.Balance);
    }

    [Fact]
    public void Deposit_RejectsNegativeAmount()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        Assert.Throws<ArgumentException>(() =>
        {
            account.Deposit(-10m);
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
    public void Withdraw_RejectsNegativeAmount()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        Assert.Throws<ArgumentException>(() =>
        {
            account.Withdraw(-10m);
        });
    }

    [Fact]
    public void Withdraw_RejectsAmountTooHigh()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        Assert.Throws<InvalidOperationException>(() =>
        {
            account.Withdraw(1200m);
        });
    }

    [Fact]
    public void SavingsAccount_AppliesInterest()
    {
        SavingsAccount account = new SavingsAccount("Jordan", 1500m, 3.5m);

        account.ApplyInterest();

        Assert.Equal(1552.5m, account.Balance);
    }

    [Fact]
    public void SavingsAccount_RejectsNegativeInterestRate()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            SavingsAccount account = new SavingsAccount("Jordan", 1500m, -1m);
        });
    }

    [Fact]
    public void CheckingAccount_WithdrawsWithFee()
    {
        CheckingAccount account = new CheckingAccount("Alex", 1500m, 2m);

        account.Withdraw(100m);

        Assert.Equal(1398m, account.Balance);
    }

    [Fact]
    public void CheckingAccount_RejectsNegativeFee()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            CheckingAccount account = new CheckingAccount("Alex", 1500m, -2m);
        });
    }

    [Fact]
    public void CheckingAccount_RejectsNegativeWithdrawal()
    {
        CheckingAccount account = new CheckingAccount("Alex", 1500m, 2m);

        Assert.Throws<ArgumentException>(() =>
        {
            account.Withdraw(-100m);
        });
    }

    [Fact]
    public void CheckingAccount_RejectsWithdrawalWhenBalanceIsTooLow()
    {
        CheckingAccount account = new CheckingAccount("Alex", 100m, 2m);

        Assert.Throws<InvalidOperationException>(() =>
        {
            account.Withdraw(100m);
        });
    }

    [Fact]
    public void DisplayAccountInfo_WritesAccountDetails()
    {
        BankAccount account = new BankAccount("Alex", 1000m);

        StringWriter output = new StringWriter();
        TextWriter originalOutput = Console.Out;

        Console.SetOut(output);
        account.DisplayAccountInfo();
        Console.SetOut(originalOutput);

        Assert.Contains("Account: BankAccount", output.ToString());
        Assert.Contains("Owner: Alex", output.ToString());
    }

    [Fact]
    public void SavingsAccount_DisplaysAccountDetails()
    {
        SavingsAccount account = new SavingsAccount("Jordan", 1500m, 3.5m);

        StringWriter output = new StringWriter();
        TextWriter originalOutput = Console.Out;

        Console.SetOut(output);
        account.DisplayAccountInfo();
        Console.SetOut(originalOutput);

        Assert.Contains("Account: SavingsAccount", output.ToString());
        Assert.Contains("Interest rate: 3.5%", output.ToString());
    }

    [Fact]
    public void CheckingAccount_DisplaysAccountDetails()
    {
        CheckingAccount account = new CheckingAccount("Alex", 1500m, 2m);

        StringWriter output = new StringWriter();
        TextWriter originalOutput = Console.Out;

        Console.SetOut(output);
        account.DisplayAccountInfo();
        Console.SetOut(originalOutput);

        Assert.Contains("Account: CheckingAccount", output.ToString());
        Assert.Contains("Transaction fee: $2.00", output.ToString());
    }
}