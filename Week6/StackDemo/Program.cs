var undoHistory = new Stack<string>();

Console.WriteLine("Initial stack contents:");
PrintStack(undoHistory);

undoHistory.Push("Typed Text");
Console.WriteLine("\nAfter Push():");
PrintStack(undoHistory);

undoHistory.Push("Inserted Image");
Console.WriteLine("\nAfter Push():");
PrintStack(undoHistory);

undoHistory.Push("Changed Colour");
Console.WriteLine("\nAfter Push():");
PrintStack(undoHistory);

Console.WriteLine($"\nTop item using Peek(): {undoHistory.Peek()}");

var removedAction = undoHistory.Pop();
Console.WriteLine($"\nPopped item: {removedAction}");

Console.WriteLine("\nStack after Pop():");
PrintStack(undoHistory);


static void PrintStack(Stack<string> stack)
{
    if (stack.Count == 0)
    {
        Console.WriteLine("Stack is empty.");
        return;
    }

    foreach (var item in stack)
    {
        Console.WriteLine(item);
    }
}