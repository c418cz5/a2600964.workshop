using System;
using System.Collections.Generic;
using System.Linq;

(string From, string To, int Weight)[] edges =
{
    ("Start", "A", 1),
    ("Start", "B (BEES)", 5),
    ("Start", "D (BEES)", 5),
    ("A", "C", 1),
    ("B (BEES)", "E (BEES)", 5),
    ("D (BEES)", "C", 5),
    ("D (BEES)", "E (BEES)", 5),
    ("D (BEES)", "G", 5),
    ("E (BEES)", "H", 5),
    ("C", "F", 1),
    ("G", "F", 1),
    ("G", "H", 1),
    ("G", "J (BEES)", 1),
    ("F", "I (BEES)", 5),
    ("H", "K", 1),
    ("J (BEES)", "I (BEES)", 5),
    ("J (BEES)", "K", 5),
    ("J (BEES)", "M", 5),
    ("I (BEES)", "L", 5),
    ("K", "N", 1),
    ("M", "L", 1),
    ("M", "N", 1),
    ("L", "End", 1)
};

var graph =
    new Dictionary<string, List<(string Neighbour, int Weight)>>();

foreach (var (fromNode, toNode, weight) in edges)
{
    if (!graph.ContainsKey(fromNode))
    {
        graph[fromNode] = new List<(string, int)>();
    }

    if (!graph.ContainsKey(toNode))
    {
        graph[toNode] = new List<(string, int)>();
    }

    graph[fromNode].Add((toNode, weight));
    graph[toNode].Add((fromNode, weight));
}

var result = FindShortestPath(graph, "Start", "End");

Console.WriteLine($"Number of nodes: {graph.Count}");
Console.WriteLine($"Number of edges: {edges.Length}");
Console.WriteLine();

if (result.Path.Count == 0)
{
    Console.WriteLine("No path found.");
}
else
{
    Console.WriteLine("AI Dijkstra path:");
    Console.WriteLine(string.Join(" -> ", result.Path));
    Console.WriteLine($"Total cost: {result.Cost}");
}

static (List<string> Path, int Cost) FindShortestPath(
    Dictionary<string, List<(string Neighbour, int Weight)>> sourceGraph,
    string start,
    string target)
{
    var distances = sourceGraph.Keys.ToDictionary(
        name => name,
        name => int.MaxValue);

    var parents = new Dictionary<string, string>();
    var queue = new PriorityQueue<string, int>();

    distances[start] = 0;
    queue.Enqueue(start, 0);

    while (queue.TryDequeue(out var current, out int queuedDistance))
    {
        if (queuedDistance != distances[current])
        {
            continue;
        }

        if (current == target)
        {
            break;
        }

        foreach (var (neighbour, weight) in sourceGraph[current])
        {
            int newDistance = queuedDistance + weight;

            if (newDistance >= distances[neighbour])
            {
                continue;
            }

            distances[neighbour] = newDistance;
            parents[neighbour] = current;
            queue.Enqueue(neighbour, newDistance);
        }
    }

    if (distances[target] == int.MaxValue)
    {
        return (new List<string>(), int.MaxValue);
    }

    var path = new List<string>();
    string pathNode = target;

    while (pathNode != start)
    {
        path.Add(pathNode);
        pathNode = parents[pathNode];
    }

    path.Add(start);
    path.Reverse();

    return (path, distances[target]);
}
