using System;
using System.Diagnostics;
using System.Text;

public class ComplexityDemo
{
    public static void Run()
    {
        const int iterations = 100_000;

        string appendOutput = "";
        var appendWatch = new Stopwatch();

        appendWatch.Start();

        for (int i = 0; i < iterations; i++)
        {
            appendOutput += "z";
        }

        appendWatch.Stop();

        var builderOutput = new StringBuilder();
        var builderWatch = new Stopwatch();

        builderWatch.Start();

        for (int i = 0; i < iterations; i++)
        {
            builderOutput.Append("z");
        }

        builderWatch.Stop();

        Console.WriteLine("String performance comparison:");
        Console.WriteLine($"Append time: {appendWatch.Elapsed.TotalMilliseconds:F2} ms");
        Console.WriteLine($"StringBuilder time: {builderWatch.Elapsed.TotalMilliseconds:F2} ms");
        Console.WriteLine($"Append length: {appendOutput.Length}");
        Console.WriteLine($"StringBuilder length: {builderOutput.Length}");
    }
}