var numbers = new LinkedList<int>();
numbers.AddFirst(5);
numbers.AddLast(10);
numbers.AddLast(20);
numbers.AddLast(30);

LinkedListNode<int> node20 = numbers.Find(20)!;
numbers.AddBefore(node20, 15);
numbers.AddAfter(node20, 25);
numbers.AddLast(35);
numbers.AddLast(40);
numbers.AddLast(45);
numbers.AddLast(50);
numbers.Remove(25);
numbers.RemoveFirst();
numbers.RemoveLast();

LinkedListNode<int> fifthNode = numbers.First!;

for (int i = 1; i < 5; i++)
{
    fifthNode = fifthNode.Next!;
}

numbers.Remove(fifthNode);

Console.WriteLine("Final linked list:");

foreach (int number in numbers)
{
    Console.WriteLine(number);
}