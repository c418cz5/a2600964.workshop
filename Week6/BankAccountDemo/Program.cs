var accountStack = new Stack<BankAccount>();

accountStack.Push(new BankAccount("Rick", 1000m));
accountStack.Push(new BankAccount("John", 2500m));
accountStack.Push(new BankAccount("Jane", 800m));
accountStack.Push(new BankAccount("Brian", 3200m));
accountStack.Push(new BankAccount("Lois", 1500m));
accountStack.Push(new BankAccount("Peter", 4500m));
accountStack.Push(new BankAccount("Stewie", 100m));
accountStack.Push(new BankAccount("Meg", 2000m));
accountStack.Push(new BankAccount("Klaus", 3700m));
accountStack.Push(new BankAccount("Kobe", 5000m));

Console.WriteLine("Stack of bank accounts:");

foreach (var account in accountStack)
{
    Console.WriteLine(account);
}

var accountQueue = StackToQueue(accountStack);

Console.WriteLine("\nQueue before sorting:");

foreach (var account in accountQueue)
{
    Console.WriteLine(account);
}

var sortedQueue = SortQueue(accountQueue);

Console.WriteLine("\nQueue after sorting:");

foreach (var account in sortedQueue)
{
    Console.WriteLine(account);
}


static Queue<BankAccount> StackToQueue(Stack<BankAccount> stack)
{
    var queue = new Queue<BankAccount>();

    foreach (var account in stack)
    {
        queue.Enqueue(account);
    }

    return queue;
}


static Queue<BankAccount> SortQueue(Queue<BankAccount> queue)
{
    var sortedQueue = new Queue<BankAccount>();

    while (queue.Count > 0)
    {
        var temporaryQueue = new Queue<BankAccount>();
        BankAccount? lowestBalanceAccount = null;

        while (queue.Count > 0)
        {
            var account = queue.Dequeue();
            temporaryQueue.Enqueue(account);

            if (lowestBalanceAccount is null ||
                account.Balance < lowestBalanceAccount.Balance)
            {
                lowestBalanceAccount = account;
            }
        }

        while (temporaryQueue.Count > 0)
        {
            var account = temporaryQueue.Dequeue();

            if (account != lowestBalanceAccount)
            {
                queue.Enqueue(account);
            }
        }

        sortedQueue.Enqueue(lowestBalanceAccount!);
    }

    return sortedQueue;
}