var accounts = new List<BankAccount>
{
    new BankAccount("Rick", 1000m),
    new BankAccount("John", 2500m),
    new BankAccount("Jane", 800m),
    new BankAccount("Brian", 3200m),
    new BankAccount("Lois", 1500m),
    new BankAccount("Peter", 4500m),
    new BankAccount("Stewie", 100m),
    new BankAccount("Meg", 2000m),
    new BankAccount("Klaus", 3700m),
    new BankAccount("Kobe", 5000m)
};

var accountStack = new Stack<BankAccount>();
var accountQueue = new Queue<BankAccount>();

foreach (var account in accounts)
{
    accountStack.Push(account);
    accountQueue.Enqueue(account);
}

var stackOwners = accountStack
    .Select(x => x.Owner)
    .OrderBy(x => x)
    .ToList();

Console.WriteLine("Stack owners ordered by name:");

foreach (var owner in stackOwners)
{
    Console.WriteLine(owner);
}

var queueOwners = accountQueue
    .Select(x => x.Owner)
    .OrderBy(x => x)
    .ToList();

Console.WriteLine("\nQueue owners ordered by name:");

foreach (var owner in queueOwners)
{
    Console.WriteLine(owner);
}
var stackFilteredAccounts = accountStack
    .Where(x => x.Owner.Contains("e"))
    .Select(x => new { x.Owner, x.Balance })
    .OrderBy(x => x.Balance)
    .ToList();

Console.WriteLine("\nStack accounts with an 'e' in the Owner:");

foreach (var account in stackFilteredAccounts)
{
    Console.WriteLine($"{account.Owner}: {account.Balance:F2}");
}

var queueFilteredAccounts = accountQueue
    .Where(x => x.Owner.Contains("e"))
    .Select(x => new { x.Owner, x.Balance })
    .OrderBy(x => x.Balance)
    .ToList();

Console.WriteLine("\nQueue accounts with an 'e' in the Owner:");

foreach (var account in queueFilteredAccounts)
{
    Console.WriteLine($"{account.Owner}: {account.Balance:F2}");
}