using System.Collections.Generic;
using System;

class TodoApp
{
    static List<string> tasks = new List<string>();

    static void Main()
    {
        Console.WriteLine("=== Todo Manager ===");
        Console.WriteLine("Commands: .add [item], show, remove [index], clear, exit");
        Console.WriteLine();

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine()?.Trim() ?? "";

            if (input == "exit") break;

            string[] parts = input.Split(' ', 2);
            string cmd = parts[0];

            switch (cmd)
            {
                case ".add":
                    if (parts.Length < 2 || string.IsNullOrWhiteSpace(parts[1]))
                    {
                        Console.WriteLine("Error: usage is .add [item]");
                    }
                    else
                    {
                        tasks.Add(parts[1]);
                        Console.WriteLine($"Added: {parts[1]}");
                    }
                    break;

                case "show":
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("Todo list is empty.");
                    }
                    else
                    {
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tasks[i]}");
                        }
                    }
                    break;

                case "remove":
                    if (parts.Length < 2)
                    {
                        Console.WriteLine("Error: usage is remove [index]");
                    }
                    else if (!int.TryParse(parts[1], out int idx) || idx < 1 || idx > tasks.Count)
                    {
                        Console.WriteLine("Error: invalid index.");
                    }
                    else
                    {
                        string removed = tasks[idx - 1];
                        tasks.RemoveAt(idx - 1);
                        Console.WriteLine($"Removed: {removed}");
                    }
                    break;

                case "clear":
                    tasks.Clear();
                    Console.WriteLine("Todo list cleared.");
                    break;

                default:
                    Console.WriteLine("Unknown command. Try: .add, show, remove, clear, exit");
                    break;
            }

            Console.WriteLine();
        }
    }
}