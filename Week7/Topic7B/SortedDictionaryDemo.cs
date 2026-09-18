using System;
using System.Collections.Generic;
using System.Linq;

public class SortedDictionaryDemo
{
    public static void Run()
    {
        RunTask1();
        RunTask2();
    }

    static void RunTask1()
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
        Console.WriteLine();
    }

    static void RunTask2()
    {
        var sortedScores = new SortedDictionary<ScoreEntry, Player>(
            new ScoreComparer());

        sortedScores.Add(new ScoreEntry(1200, 1), new Player("Player A"));
        sortedScores.Add(new ScoreEntry(1800, 2), new Player("Player B"));
        sortedScores.Add(new ScoreEntry(2500, 3), new Player("Player C"));
        sortedScores.Add(new ScoreEntry(3100, 4), new Player("Player D"));
        sortedScores.Add(new ScoreEntry(3900, 5), new Player("Player E"));
        sortedScores.Add(new ScoreEntry(4500, 6), new Player("Player F"));
        sortedScores.Add(new ScoreEntry(5200, 7), new Player("Player G"));
        sortedScores.Add(new ScoreEntry(6100, 8), new Player("Player H"));
        sortedScores.Add(new ScoreEntry(7200, 9), new Player("Player I"));
        sortedScores.Add(new ScoreEntry(8500, 10), new Player("Player J"));

        Console.WriteLine("Task 2 top three scores:");

        foreach (var entry in sortedScores.Reverse().Take(3))
        {
            Console.WriteLine(
                $"{entry.Value.Name}: {entry.Key.Score}, Stage {entry.Key.StageReached}");
        }

        Console.WriteLine();
        Console.WriteLine("Task 2 bottom three scores:");

        foreach (var entry in sortedScores.Take(3))
        {
            Console.WriteLine(
                $"{entry.Value.Name}: {entry.Key.Score}, Stage {entry.Key.StageReached}");
        }

        var playerToRemove = sortedScores.First(
            entry => entry.Value.Name == "Player D");

        sortedScores.Remove(playerToRemove.Key);

        Console.WriteLine();
        Console.WriteLine("After Player D left:");

        foreach (var entry in sortedScores)
        {
            Console.WriteLine(
                $"{entry.Value.Name}: {entry.Key.Score}, Stage {entry.Key.StageReached}");
        }

        var sameScoreEntry = new ScoreEntry(4500, 99);
        sortedScores.Add(sameScoreEntry, new Player("Player K"));

        Console.WriteLine();
        Console.WriteLine("Added a player with the same score and a different stage.");

        var samePlayer = sortedScores.First(
            entry => entry.Value.Name == "Player A").Value;

        sortedScores.Add(new ScoreEntry(9000, 11), samePlayer);

        Console.WriteLine("Added the same Player object with a different score.");

        Console.WriteLine();
        Console.WriteLine("Final scores:");

        foreach (var entry in sortedScores)
        {
            Console.WriteLine(
                $"{entry.Value.Name}: {entry.Key.Score}, Stage {entry.Key.StageReached}");
        }
    }
}