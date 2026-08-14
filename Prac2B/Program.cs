BankAccount account = new BankAccount("Alex", 1000m);

Console.WriteLine($"Starting balance: ${account.Balance:F2}");

account.Deposit(100);

Console.WriteLine($"After int deposit: ${account.Balance:F2}");

account.Deposit(50.5);

Console.WriteLine($"After double deposit: ${account.Balance:F2}");

account.Deposit(25.5m);

Console.WriteLine($"After decimal deposit: ${account.Balance:F2}");