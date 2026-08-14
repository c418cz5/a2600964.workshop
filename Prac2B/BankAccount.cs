public class BankAccount
{

    public string Owner { get; set; }

    public decimal Balance { get; private set; }

  
    public BankAccount(string owner, decimal balance)
    {
        Owner = owner;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive");
        }

        Balance = Balance + amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive");
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Not enough balance");
        }

        Balance = Balance - amount;
    }
}