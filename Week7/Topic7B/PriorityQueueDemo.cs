using System;
using System.Collections.Generic;

public enum Priority
{
    HighPriority,
    MediumPriority,
    LowPriority
}

public class PriorityQueueDemo
{
    public static void Run()
    {
        RunTask3();
    }

    static void RunTask3()
    {
        var eventQueue = new PriorityQueue<Player, int>();

        var playerA = new Player("Player A");
        var playerB = new Player("Player B");
        var playerC = new Player("Player C");

        eventQueue.Enqueue(playerA, 3);
        eventQueue.Enqueue(playerB, 1);
        eventQueue.Enqueue(playerC, 2);

        Console.WriteLine("Players processed by priority:");

        while (eventQueue.Count != 0)
        {
            Console.WriteLine(eventQueue.Dequeue());
        }

        Console.WriteLine();
        Console.WriteLine("Adding two players with the same priority:");

        eventQueue.Enqueue(playerA, 2);
        eventQueue.Enqueue(playerB, 2);
        eventQueue.Enqueue(playerC, 1);

        while (eventQueue.Count != 0)
        {
            Console.WriteLine(eventQueue.Dequeue());
        }
    }

    public static void RunTask4()
    {
        var eventQueue = new PriorityQueue<Player, Priority>();

        var playerA = new Player("Player A");
        var playerB = new Player("Player B");
        var playerC = new Player("Player C");

        eventQueue.Enqueue(playerA, Priority.LowPriority);
        eventQueue.Enqueue(playerB, Priority.HighPriority);
        eventQueue.Enqueue(playerC, Priority.MediumPriority);

        Console.WriteLine("Players processed by enum priority:");

        while (eventQueue.Count != 0)
        {
            Console.WriteLine(eventQueue.Dequeue());
        }

        Console.WriteLine();
        Console.WriteLine("Adding two players with the same enum priority:");

        eventQueue.Enqueue(playerA, Priority.MediumPriority);
        eventQueue.Enqueue(playerB, Priority.MediumPriority);
        eventQueue.Enqueue(playerC, Priority.HighPriority);

        while (eventQueue.Count != 0)
        {
            Console.WriteLine(eventQueue.Dequeue());
        }
    }
}