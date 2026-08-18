public class BankAccount
{
    public string Owner { get; set; }

    public decimal Balance { get; protected set; }

    public BankAccount(string owner, decimal balance)
    {
        if (balance < 0)
        {
            throw new ArgumentException("Balance cannot be negative");
        }

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

    public void Deposit(int amount)
    {
        Deposit((decimal)amount);
    }

    public void Deposit(double amount)
    {
        Deposit((decimal)amount);
    }

    public virtual void Withdraw(decimal amount)
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