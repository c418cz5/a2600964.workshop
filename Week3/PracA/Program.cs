SavingsAccount savings = new SavingsAccount("Jordan", 1500m, 3.5m);

Console.WriteLine($"Savings owner: {savings.Owner}");
Console.WriteLine($"Starting balance: ${savings.Balance:F2}");

savings.ApplyInterest();

Console.WriteLine($"After interest: ${savings.Balance:F2}");

CheckingAccount checking = new CheckingAccount("Alex", 1500m, 2m);

Console.WriteLine($"Checking owner: {checking.Owner}");
Console.WriteLine($"Starting balance: ${checking.Balance:F2}");

checking.Withdraw(100m);

Console.WriteLine($"After withdrawal and fee: ${checking.Balance:F2}");