BankAccount account = new BankAccount("Alex", 1000m);

Console.WriteLine($"Owner: {account.Owner}");
Console.WriteLine($"Starting balance: ${account.Balance:F2}");

account.Deposit(250m);

Console.WriteLine($"After deposit: ${account.Balance:F2}");

account.Withdraw(100m);

Console.WriteLine($"After withdrawal: ${account.Balance:F2}");