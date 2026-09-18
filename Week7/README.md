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

## Topic 7 Prac B Reflection

### Task 1: SortedDictionary

`SortedDictionary<int, string>` keeps the players ordered by their score automatically. It is backed by a balanced binary search tree, so it is useful for maintaining rankings.

The top three scores were found by reversing the dictionary and using `Take(3)`. The bottom three were found using `Take(3)`. Adding another player with the same score caused an `ArgumentException` because dictionary keys must be unique. Adding the same player name with a different score worked because the name is only a value, not a key.

### Task 2: ScoreEntry and Player

When I first used `ScoreEntry` as the key, the program produced an error because `ScoreEntry` did not implement `IComparable`. I fixed this by creating a `ScoreComparer`.

The comparer first compares the score and then compares `StageReached` when two scores are the same. This allows two players to have the same score if they reached different stages. The same `Player` object can also be used with different scores because only the keys need to be unique.

This would be useful for a leaderboard where players can have the same score but different stages or achievement times.

### Task 3: PriorityQueue with Integer Priorities

`PriorityQueue<Player, int>` processes the player with the lowest priority number first. The data structure is based on a heap.

Two players can have the same priority. Both players remain in the queue and are eventually processed. However, their order is not guaranteed when their priorities are equal. Unlike `SortedSet`, a `PriorityQueue` does not remove duplicate elements because it is designed to manage priority, not uniqueness.

### Task 4: PriorityQueue with an Enum

The enum worked without writing a custom comparer because enum values already have an underlying numeric order. `HighPriority` has the value `0`, `MediumPriority` has the value `1`, and `LowPriority` has the value `2`.

If I used a custom struct with an integer property, I would normally need to implement `IComparable` or provide an `IComparer`. The priority queue would not automatically know how to compare two custom structs.

Priority queues are useful for game events, AI actions, and scheduling tasks. For example, an enemy could attack before collecting an item if the attack event has a higher priority.