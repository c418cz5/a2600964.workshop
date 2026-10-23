using System;
using System.Linq;
using System.Collections.Generic;

var graph = new Graph();

var Start = new Node("Start");
var A = new Node("A");
var B = new Node("B (BEES)");
var C = new Node("C");
var D = new Node("D (BEES)");
var E = new Node("E (BEES)");
var F = new Node("F");
var G = new Node("G");
var H = new Node("H");
var I = new Node("I (BEES)");
var J = new Node("J (BEES)");
var K = new Node("K");
var L = new Node("L");
var M = new Node("M");
var N = new Node("N");
var End = new Node("End");

graph.AddEdge(Start, A, 1);
graph.AddEdge(Start, B, 5);
graph.AddEdge(Start, D, 5);

graph.AddEdge(A, C, 1);
graph.AddEdge(B, E, 5);

graph.AddEdge(D, C, 5);
graph.AddEdge(D, E, 5);
graph.AddEdge(D, G, 5);

graph.AddEdge(E, H, 5);
graph.AddEdge(C, F, 1);

graph.AddEdge(G, F, 1);
graph.AddEdge(G, H, 1);
graph.AddEdge(G, J, 1);

graph.AddEdge(F, I, 5);
graph.AddEdge(H, K, 1);

graph.AddEdge(J, I, 5);
graph.AddEdge(J, K, 5);
graph.AddEdge(J, M, 5);

graph.AddEdge(I, L, 5);
graph.AddEdge(K, N, 1);

graph.AddEdge(M, L, 1);
graph.AddEdge(M, N, 1);

graph.AddEdge(L, End, 1);

Console.WriteLine("Weighted horse graph:");
Console.WriteLine(graph);

Console.WriteLine($"Number of nodes: {graph.Nodes.Count}");

int edgeCount = graph.Nodes.Sum(node => node.Edges.Count) / 2;
Console.WriteLine($"Number of edges: {edgeCount}");
var target = End;
var distanceList = new Dictionary<Node, int>();

foreach (var node in graph.Nodes)
{
    distanceList[node] = int.MaxValue;
}

distanceList[Start] = 0;

var priorityQueue = new PriorityQueue<Node, int>();
var parents = new Dictionary<Node, Node?>();

parents[Start] = null;
priorityQueue.Enqueue(Start, 0);

while (priorityQueue.Count > 0)
{
    var current = priorityQueue.Dequeue();

    if (current == target)
    {
        break;
    }

    foreach (var neighbour in current.Edges)
    {
        int totalDistance =
            distanceList[current] + neighbour.Value;

        if (totalDistance >= distanceList[neighbour.Key])
        {
            continue;
        }

        distanceList[neighbour.Key] = totalDistance;
        parents[neighbour.Key] = current;

        priorityQueue.Enqueue(neighbour.Key, totalDistance);
    }
}

Console.WriteLine();

if (distanceList[target] == int.MaxValue)
{
    Console.WriteLine("No path found.");
    return;
}

var path = new List<string>();
Node? pathNode = target;

while (pathNode != null)
{
    path.Add(pathNode.Data);
    pathNode = parents[pathNode];
}

path.Reverse();

Console.WriteLine("Dijkstra path:");
Console.WriteLine(string.Join(" -> ", path));
Console.WriteLine($"Total cost: {distanceList[target]}");