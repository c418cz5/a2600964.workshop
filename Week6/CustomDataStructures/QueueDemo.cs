using System;

namespace CustomDataStructures
{
    class QueueDemo
    {
        public static void Run()
        {
            var myQueue = new CustomDataStructures.Queue<int>();

            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);

            Console.WriteLine($"Peek front value: {myQueue.Peek()}");
            Console.WriteLine($"Dequeue value: {myQueue.Dequeue()}");
            Console.WriteLine($"Peek after dequeue: {myQueue.Peek()}");

            Console.WriteLine($"Is empty? {myQueue.IsEmpty()}");

            myQueue.Dequeue();
            myQueue.Dequeue();
            Console.WriteLine($"Is empty? {myQueue.IsEmpty()}");

            // myQueue.Dequeue();
        }
    }
}
