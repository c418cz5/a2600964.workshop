var graph = new Graph();

var A = new Node("A");
var B = new Node("B");
var C = new Node("C");
var D = new Node("D");
var E = new Node("E");
var F = new Node("F");
var G = new Node("G");
var H = new Node("H");
var I = new Node("I");

graph.AddEdge(A, B);
graph.AddEdge(A, C);
graph.AddEdge(B, D);
graph.AddEdge(B, E);
graph.AddEdge(C, F);
graph.AddEdge(D, G);
graph.AddEdge(E, H);
graph.AddEdge(F, I);

Console.WriteLine("Graph nodes and edges:");
Console.WriteLine(graph);
Console.WriteLine($"Number of nodes: {graph.Nodes.Count}");