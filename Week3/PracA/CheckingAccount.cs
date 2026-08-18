public class CheckingAccount : BankAccount
{
  
    public decimal TransactionFee { get; set; }

  
    public CheckingAccount(string owner, decimal balance, decimal transactionFee)
        : base(owner, balance)
    {
        if (transactionFee < 0)
        {
            throw new ArgumentException("Transaction fee cannot be negative");
        }

        TransactionFee = transactionFee;
    }


    public override void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive");
        }

        base.Withdraw(amount + TransactionFee);
    }

    public override void DisplayAccountInfo()
    {
        Console.WriteLine("Account: CheckingAccount");
        Console.WriteLine($"Owner: {Owner}");
        Console.WriteLine($"Balance: ${Balance:F2}");
        Console.WriteLine($"Transaction fee: ${TransactionFee:F2}");
    }
}