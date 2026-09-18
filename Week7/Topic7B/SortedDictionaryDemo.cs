using System;
using System.Collections.Generic;
using System.Linq;

public class SortedDictionaryDemo
{
    public static void Run()
    {
        var sortedScores = new SortedDictionary<int, string>();

        sortedScores.Add(1200, "Player A");
        sortedScores.Add(1800, "Player B");
        sortedScores.Add(2500, "Player C");
        sortedScores.Add(3100, "Player D");
        sortedScores.Add(3900, "Player E");
        sortedScores.Add(4500, "Player F");
        sortedScores.Add(5200, "Player G");
        sortedScores.Add(6100, "Player H");
        sortedScores.Add(7200, "Player I");
        sortedScores.Add(8500, "Player J");

        Console.WriteLine("Top three scores:");

        foreach (var entry in sortedScores.Reverse().Take(3))
        {
            Console.WriteLine($"{entry.Value}: {entry.Key}");
        }

        Console.WriteLine();
        Console.WriteLine("Bottom three scores:");

        foreach (var entry in sortedScores.Take(3))
        {
            Console.WriteLine($"{entry.Value}: {entry.Key}");
        }

        var playerToRemove = sortedScores.First(entry => entry.Value == "Player D");
        sortedScores.Remove(playerToRemove.Key);

        Console.WriteLine();
        Console.WriteLine("After Player D left:");

        foreach (var entry in sortedScores)
        {
            Console.WriteLine($"{entry.Value}: {entry.Key}");
        }

        Console.WriteLine();
        Console.WriteLine("Trying to add a duplicate score:");

        try
        {
            sortedScores.Add(4500, "Another Player");
        }
        catch (ArgumentException error)
        {
            Console.WriteLine($"Error: {error.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Trying to add the same player with a different score:");

        sortedScores.Add(9000, "Player A");
        Console.WriteLine("Player A was added with a different score.");
    }
}