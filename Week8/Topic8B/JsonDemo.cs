using System;
using System.Collections.Generic;
using System.IO;

public class JsonDemo
{
    public static void Run()
    {
        var players = new List<Player>
        {
            new Player("Player A", 100, 10, 5),
            new Player("Player B", 120, 15, 8),
            new Player("Player C", 90, 20, 4),
            new Player("Player D", 150, 12, 10),
            new Player("Player E", 80, 25, 3)
        };

        string path = @"../Attachments/players.json";

        FileHelper.FileWriter<List<Player>>(path, players);

        List<Player> loadedPlayers =
            FileHelper.FileReader<List<Player>>(path);

        Console.WriteLine($"Loaded players: {loadedPlayers.Count}");

        foreach (var player in loadedPlayers)
        {
            Console.WriteLine(player);
            Console.WriteLine();
        }

        Console.WriteLine($"File path: {Path.GetFullPath(path)}");
    }
}