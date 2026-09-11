# Topic 6 Reflection Notes

## Prac A Reflection

In this topic, I learned that a Stack uses LIFO, which means Last In, First Out. A Queue uses FIFO, which means First In, First Out.

In Task 3, I used `StackToQueue()` to copy the accounts from a Stack to a Queue. The order stayed the same because the Stack was read from top to bottom.

In Task 4, I used a temporary Queue to find the account with the lowest balance. I moved the lowest account to a new Queue and repeated this process until all accounts were sorted. This helped me understand how Queue operations work.

## Prac B Task 1

Before using `ToList()`, `names.OrderBy(x => x)` returns an `IOrderedEnumerable<string>`. It is an ordered collection, but it is not a normal `List<string>` yet.

`OrderBy()` returns a new ordered result instead of changing the original list. This means the original data can stay unchanged. It also makes it possible to use other LINQ methods after it.

The expression `x => x` is a lambda expression. It means that each name is sorted by itself.

`x` represents the current item in the list. I can use another name, such as `name`, instead of `x`. The type of `x` is not written because C# can understand it from `List<string>`. In this case, `x` is a `string`.

## Prac B Task 2

The syntax did not need to change between the Stack and the Queue. Both collections implement `IEnumerable`, so LINQ methods can be used on both of them.

The only difference was the collection variable:

```csharp
accountStack
accountQueue
```

The query structure was the same:

```csharp
.Select(x => x.Owner)
.OrderBy(x => x)
```

This selected the Owner property and sorted the names alphabetically.

## Prac B Task 3

I prefer using LINQ because the code is shorter and easier to read. The previous sorting algorithm needed nested loops, a temporary Queue, `Dequeue()` and `Enqueue()`. However, the manual algorithm helped me understand what happens inside a Queue.

At first, the LINQ syntax was a little unusual because the lambda expressions were new to me. After using `Where()`, `Select()` and `OrderBy()` several times, it became easier to understand.

The syntax did not need to change between the Stack and the Queue. Both can use the same LINQ methods. In this task, `Where()` filtered the owners, `Select()` returned the Owner and Balance, and `OrderBy()` sorted the results by Balance.
