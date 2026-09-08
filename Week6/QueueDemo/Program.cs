var printerJobs = new Queue<string>();

Console.WriteLine("Initial queue contents:");
PrintQueue(printerJobs);

printerJobs.Enqueue("Print Job 1");
Console.WriteLine("\nAfter Enqueue():");
PrintQueue(printerJobs);

printerJobs.Enqueue("Print Job 2");
Console.WriteLine("\nAfter Enqueue():");
PrintQueue(printerJobs);

printerJobs.Enqueue("Print Job 3");
Console.WriteLine("\nAfter Enqueue():");
PrintQueue(printerJobs);

Console.WriteLine($"\nFront item using Peek(): {printerJobs.Peek()}");

var completedJob = printerJobs.Dequeue();
Console.WriteLine($"\nDequeued item: {completedJob}");

Console.WriteLine("\nQueue after Dequeue():");
PrintQueue(printerJobs);


static void PrintQueue(Queue<string> queue)
{
    if (queue.Count == 0)
    {
        Console.WriteLine("Queue is empty.");
        return;
    }

    foreach (var item in queue)
    {
        Console.WriteLine(item);
    }
}