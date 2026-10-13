using System;
using System.Collections;
using System.Linq;

public class HashtableDemo
{
    public static void Run()
    {
        var scoreHash = new Hashtable();

        var playerA = new Player("Player A");
        var playerB = new Player("Player B");
        var playerC = new Player("Player C");
        var playerD = new Player("Player D");
        var playerE = new Player("Player E");

        scoreHash.Add(playerA, 1200);
        scoreHash.Add(playerB, 5800);
        scoreHash.Add(playerC, 3200);
        scoreHash.Add(playerD, 8500);
        scoreHash.Add(playerE, 4500);

        Console.WriteLine("Players and scores:");

        foreach (DictionaryEntry entry in scoreHash)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }

        Console.WriteLine();
        Console.WriteLine("Trying to add a string key:");

        scoreHash.Add("Not a Player", 2000);
        Console.WriteLine("The string key was added.");

        Console.WriteLine();
        Console.WriteLine("Trying to add a duplicate key:");

        try
        {
            scoreHash.Add(playerA, 9999);
        }
        catch (ArgumentException error)
        {
            Console.WriteLine($"Error: {error.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Scores sorted in descending order:");

        var sortedScores = scoreHash
            .Cast<DictionaryEntry>()
            .OrderByDescending(entry => Convert.ToInt32(entry.Value));

        foreach (var entry in sortedScores)
        {
            if (entry.Key is Player player)
            {
                Console.WriteLine($"{player.Name}: {entry.Value}");
            }
            else
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}