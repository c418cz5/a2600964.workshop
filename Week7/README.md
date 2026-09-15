# Topic 7 Prac A Reflection

## Task 1: SortedSet<int>

`SortedSet<int>` kept the scores in ascending order automatically, so I did not need to call `Sort()`.

I found that `SortedSet` uses a self-balancing binary search tree to store the values. I checked this in the .NET documentation and source information.

When I added a duplicate score, `Add()` returned `False` and the number of scores did not change. This is because a set only stores unique values.

This could be used for a game leaderboard where scores need to stay ordered and duplicate scores are not needed.

## Task 2: SortedSet<BankAccount>

The first `SortedSet<BankAccount>` compiled, but adding the accounts caused an `IComparable` error. `BankAccount` did not have a default way to compare two objects.

I fixed this by creating `BankComparer`. It compares the account balance first, then the owner name if two balances are the same.

The accounts were then displayed from the lowest balance to the highest balance. Adding the same owner and balance again returned `False`, so it was not added.

This is similar to sorting players or game objects by a score, value, or another property.

## Task 3: ScottPlot

I converted the balances from the `SortedSet<BankAccount>` into a `double[]` and used ScottPlot to create a bar chart.

The chart is saved as `Topic7A-Task3.png` with the labels `Ranking` and `Account Balance`. It helps make the ordered account data easier to understand visually.
