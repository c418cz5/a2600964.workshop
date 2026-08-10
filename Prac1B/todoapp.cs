using System;
using System.Collections.Generic;

class TodoApp
{
    static List<string> tasks = new List<string>();
    static Dictionary<string, List<int>> tags = new Dictionary<string, List<int>>();

    static void Main()
    {
        Person person = new Person("Alex", "Wang", 20);

        Console.WriteLine(person.FirstName);
        Console.WriteLine(person.LastName);
        Console.WriteLine(person.Age);
        Console.WriteLine(person.FullName());
        Console.WriteLine(person.IsAdult());

        Console.WriteLine();

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine()?.Trim() ?? "";

            if (input == "exit")
                break;

            string[] parts = input.Split(' ', 3);
            string command = parts[0];

            switch (command)
            {
                case ".add":
                    AddTask(parts);
                    break;

                case "show":
                    ShowTasks();
                    break;

                case "remove":
                    RemoveTask(parts);
                    break;

                case "clear":
                    ClearTasks();
                    break;

                case ".tag":
                    AddTag(parts);
                    break;

                case "get-tagged":
                    GetTaggedItems(parts);
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddTask(string[] parts)
    {
        if (parts.Length < 2 || parts[1].Trim() == "")
        {
            Console.WriteLine("Error: .add needs an item");
        }
        else
        {
            tasks.Add(parts[1]);
            Console.WriteLine("Added: " + parts[1]);
        }
    }

    static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Nothing in the list.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + tasks[i]);
            }
        }
    }

    static void RemoveTask(string[] parts)
    {
        if (parts.Length < 2)
        {
            Console.WriteLine("Error: remove needs an index");
            return;
        }

        int index;
        bool valid = int.TryParse(parts[1], out index);

        if (!valid || index < 1 || index > tasks.Count)
        {
            Console.WriteLine("Error: index is not valid");
            return;
        }

        int realIndex = index - 1;
        string removed = tasks[realIndex];

        tasks.RemoveAt(realIndex);
        UpdateTagIndexes(realIndex);

        Console.WriteLine("Removed: " + removed);
    }

    static void UpdateTagIndexes(int removedIndex)
    {
        foreach (var tagList in tags.Values)
        {
            tagList.Remove(removedIndex);

            for (int i = 0; i < tagList.Count; i++)
            {
                if (tagList[i] > removedIndex)
                {
                    tagList[i]--;
                }
            }
        }
    }

    static void ClearTasks()
    {
        tasks.Clear();
        tags.Clear();
        Console.WriteLine("List cleared.");
    }

    static void AddTag(string[] parts)
    {
        if (parts.Length < 3)
        {
            Console.WriteLine("Error: .tag [index] [name]");
            return;
        }

        int index;
        bool valid = int.TryParse(parts[1], out index);

        if (!valid || index < 1 || index > tasks.Count)
        {
            Console.WriteLine("Error: bad index");
            return;
        }

        int realIndex = index - 1;
        string tagName = parts[2];

        if (!tags.ContainsKey(tagName))
        {
            tags[tagName] = new List<int>();
        }

        if (tags[tagName].Contains(realIndex))
        {
            Console.WriteLine("Already tagged.");
        }
        else
        {
            tags[tagName].Add(realIndex);
            Console.WriteLine("Tagged item " + index + " with '" + tagName + "'");
        }
    }

    static void GetTaggedItems(string[] parts)
    {
        if (parts.Length < 2)
        {
            Console.WriteLine("Error: get-tagged [tag name]");
            return;
        }

        string tagName = parts[1];

        if (!tags.ContainsKey(tagName))
        {
            Console.WriteLine("Error: tag doesn't exist");
            return;
        }

        List<int> indices = tags[tagName];

        if (indices.Count == 0)
        {
            Console.WriteLine("No items with that tag.");
            return;
        }

        Console.WriteLine("Items tagged '" + tagName + "':");

        foreach (int index in indices)
        {
            Console.WriteLine("  " + (index + 1) + ". " + tasks[index]);
        }
    }
}