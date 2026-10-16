using System;
using System.Collections.Generic;
using System.Diagnostics;

public class LinkedListMemoryDemo
{
    public static void Run()
    {
        var players = new LinkedList<Player>();

        players.AddLast(new Player("Player A", 100, 10, 5));
        players.AddLast(new Player("Player B", 120, 15, 8));
        players.AddLast(new Player("Player C", 90, 20, 4));
        players.AddLast(new Player("Player D", 150, 12, 10));
        players.AddLast(new Player("Player E", 80, 25, 3));

        string path = @"../Attachments/linkedPlayers.json";

        FileHelper.FileWriter<LinkedList<Player>>(path, players);

        LinkedList<Player> loadedPlayers =
            FileHelper.FileReader<LinkedList<Player>>(path);

        GC.Collect();

        long heapSize = GC.GetGCMemoryInfo().HeapSizeBytes;

        using var process = Process.GetCurrentProcess();
        long peakMemory = process.PeakWorkingSet64;

        Console.WriteLine("LinkedList memory usage:");
        Console.WriteLine($"Loaded players: {loadedPlayers.Count}");
        Console.WriteLine($"HeapSizeBytes: {heapSize:N0} bytes");
        Console.WriteLine($"PeakWorkingSet64: {peakMemory:N0} bytes");

        GC.KeepAlive(players);
        GC.KeepAlive(loadedPlayers);
    }
}