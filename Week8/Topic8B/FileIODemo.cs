using System;
using System.IO;

public class FileIODemo
{
    public static void Run()
    {
        string path = @"../Attachments/MyTest.txt";

        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine("Hello World");
        }

        string text = File.ReadAllText(path);

        Console.WriteLine("File content:");
        Console.Write(text);
        Console.WriteLine($"File path: {Path.GetFullPath(path)}");
    }
}