using System;
using System.Collections.Generic;

public class SortedSetDemo
{
    public static void Run()
    {
        var scores = new SortedSet<int>();
        var random = new Random();

        while (scores.Count < 10)
        {
            scores.Add(random.Next(1000, 10000));
        }

        Console.WriteLine("Original scores:");
        DisplayScores(scores);

        scores.Add(15000);

        Console.WriteLine("After adding a new high score:");
        DisplayScores(scores);

        var duplicateScore = scores.Min;
        var duplicateAdded = scores.Add(duplicateScore);

        Console.WriteLine($"Trying to add duplicate score: {duplicateAdded}");
        DisplayScores(scores);
    }

    static void DisplayScores(SortedSet<int> scores)
    {
        Console.WriteLine("Scores:");

        foreach (var score in scores)
        {
            Console.WriteLine(score);
        }

        Console.WriteLine($"Lowest score: {scores.Min}");
        Console.WriteLine($"Highest score: {scores.Max}");
        Console.WriteLine($"Number of scores: {scores.Count}");
        Console.WriteLine();
    }
}