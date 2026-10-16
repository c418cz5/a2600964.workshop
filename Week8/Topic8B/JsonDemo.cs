using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(players, options);

        Console.WriteLine("Players as JSON:");
        Console.WriteLine(jsonString);

        File.WriteAllText(path, jsonString);

        string loadedJson = File.ReadAllText(path);
        List<Player> loadedPlayers =
            JsonSerializer.Deserialize<List<Player>>(loadedJson)!;

        Console.WriteLine();
        Console.WriteLine($"Loaded players: {loadedPlayers.Count}");

        foreach (var player in loadedPlayers)
        {
            Console.WriteLine(player);
            Console.WriteLine();
        }

        Console.WriteLine($"File path: {Path.GetFullPath(path)}");
    }
}