using System;
using System.Collections.Generic;
using System.Diagnostics;

public class MemoryBenchmarkDemo
{
    public static void RunList()
    {
        var players = new List<Player>();

        for (int i = 0; i < 10_000; i++)
        {
            players.Add(new Player($"Player {i}"));
        }

        string path = @"../Attachments/list10000.json";

        FileHelper.FileWriter<List<Player>>(path, players);

        List<Player> loadedPlayers =
            FileHelper.FileReader<List<Player>>(path);

        GC.Collect();

        long heapSize = GC.GetGCMemoryInfo().HeapSizeBytes;

        using var process = Process.GetCurrentProcess();
        long peakMemory = process.PeakWorkingSet64;

        Console.WriteLine("List memory usage:");
        Console.WriteLine($"Loaded players: {loadedPlayers.Count}");
        Console.WriteLine($"HeapSizeBytes: {heapSize:N0} bytes");
        Console.WriteLine($"PeakWorkingSet64: {peakMemory:N0} bytes");

        GC.KeepAlive(players);
        GC.KeepAlive(loadedPlayers);
    }

    public static void RunLinkedList()
    {
        var players = new LinkedList<Player>();

        for (int i = 0; i < 10_000; i++)
        {
            players.AddLast(new Player($"Player {i}"));
        }

        string path = @"../Attachments/linkedList10000.json";

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