using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class GraphingDemo
{
    public static void Run()
    {
        int iterations = 20;

        var appendElapsedList = new List<double>();
        var builderElapsedList = new List<double>();

        string appendOutput = "";

        for (int pass = 1; pass <= iterations; pass++)
        {
            appendOutput = "";

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < pass * 10_000; i++)
            {
                appendOutput += "z";
            }

            watch.Stop();
            appendElapsedList.Add(watch.Elapsed.TotalMilliseconds);
        }

        var builderOutput = new StringBuilder();

        for (int pass = 1; pass <= iterations; pass++)
        {
            builderOutput.Clear();

            var watch = Stopwatch.StartNew();

            for (int i = 0; i < pass * 10_000; i++)
            {
                builderOutput.Append("z");
            }

            watch.Stop();
            builderElapsedList.Add(watch.Elapsed.TotalMilliseconds);
        }

        double[] xValues = new double[iterations];

        for (int i = 0; i < iterations; i++)
        {
            xValues[i] = i + 1;
        }

        var appendPlot = new ScottPlot.Plot();

        appendPlot.Add.Scatter(
            xValues,
            appendElapsedList.ToArray());

        appendPlot.Title("String Append Performance");
        appendPlot.XLabel("Pass");
        appendPlot.YLabel("Time (milliseconds)");
        appendPlot.SavePng("appendPlot.png", 800, 600);

        var buildPlot = new ScottPlot.Plot();

        buildPlot.Add.Scatter(
            xValues,
            builderElapsedList.ToArray());

        buildPlot.Title("StringBuilder Performance");
        buildPlot.XLabel("Pass");
        buildPlot.YLabel("Time (milliseconds)");
        buildPlot.SavePng("buildPlot.png", 800, 600);

        Console.WriteLine($"Append final length: {appendOutput.Length}");
        Console.WriteLine($"StringBuilder final length: {builderOutput.Length}");
        Console.WriteLine("appendPlot.png saved");
        Console.WriteLine("buildPlot.png saved");
    }
}