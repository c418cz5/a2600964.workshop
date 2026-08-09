using System.Collections.Generic;
using System;

class TodoApp
{
    static List<string> tasks = new List<string>();
    static Dictionary<string, List<int>> tags = new Dictionary<string, List<int>>();

    static void Main()
    {
        Console.WriteLine("=== Todo Manager ===");
        Console.WriteLine("Commands: .add [item], show, remove [index], clear");
        Console.WriteLine("          .tag [index] [name], get-tagged [tag], exit");
        Console.WriteLine();

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine()?.Trim() ?? "";

            if (input == "exit")
                break;

            string[] parts = input.Split(' ', 3);
            string cmd = parts[0];

            switch (cmd)
            {
                case ".add":
                    if (parts.Length < 2 || parts[1].Trim() == "")
                    {
                        Console.WriteLine("Error: .add needs an item");
                    }
                    else
                    {
                        tasks.Add(parts[1]);
                        Console.WriteLine("Added: " + parts[1]);
                    }
                    break;

                case "show":
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
                    break;

                case "remove":
                    if (parts.Length < 2)
                    {
                        Console.WriteLine("Error: remove needs an index");
                    }
                    else
                    {
                        int idx;
                        bool ok = int.TryParse(parts[1], out idx);
                        if (!ok || idx < 1 || idx > tasks.Count)
                        {
                            Console.WriteLine("Error: index is not valid");
                        }
                        else
                        {
                            int realIdx = idx - 1;
                            string removed = tasks[realIdx];
                            tasks.RemoveAt(realIdx);

                            // update all tag indices after removal
                            foreach (var tagList in tags.Values)
                            {
                                tagList.Remove(realIdx);
                                for (int i = 0; i < tagList.Count; i++)
                                {
                                    if (tagList[i] > realIdx)
                                        tagList[i]--;
                                }
                            }

                            Console.WriteLine("Removed: " + removed);
                        }
                    }
                    break;

                case "clear":
                    tasks.Clear();
                    tags.Clear();
                    Console.WriteLine("List cleared.");
                    break;

                case ".tag":
                    if (parts.Length < 3)
                    {
                        Console.WriteLine("Error: .tag [index] [name]");
                    }
                    else
                    {
                        int idx;
                        bool ok = int.TryParse(parts[1], out idx);
                        if (!ok || idx < 1 || idx > tasks.Count)
                        {
                            Console.WriteLine("Error: bad index");
                        }
                        else
                        {
                            int realIdx = idx - 1;
                            string tagName = parts[2];

                            if (!tags.ContainsKey(tagName))
                                tags[tagName] = new List<int>();

                            if (tags[tagName].Contains(realIdx))
                            {
                                Console.WriteLine("Already tagged.");
                            }
                            else
                            {
                                tags[tagName].Add(realIdx);
                                Console.WriteLine("Tagged item " + idx + " with '" + tagName + "'");
                            }
                        }
                    }
                    break;

                case "get-tagged":
                    if (parts.Length < 2)
                    {
                        Console.WriteLine("Error: get-tagged [tag name]");
                    }
                    else
                    {
                        string tagName = parts[1];
                        if (!tags.ContainsKey(tagName))
                        {
                            Console.WriteLine("Error: tag doesn't exist");
                        }
                        else
                        {
                            var indices = tags[tagName];
                            if (indices.Count == 0)
                            {
                                Console.WriteLine("No items with that tag.");
                            }
                            else
                            {
                                Console.WriteLine("Items tagged '" + tagName + "':");
                                foreach (int i in indices)
                                {
                                    Console.WriteLine("  " + (i + 1) + ". " + tasks[i]);
                                }
                            }
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }

            Console.WriteLine();
        }
    }
}