# Week 9 Reflection

Student: Weiyu Liu
Student ID: a2600964

## Prac A

### Task 1 - Building a Graph

**What kind of graph did I create?**

The original graph is undirected, acyclic and unweighted. Each edge connects both ways, there are no cycles, and the edges have no weights. It is also a tree.

**What other data structures are also graphs?**

Binary heaps and tries are both tree structures, so they are also graphs.

### Task 2 - BFS

**Why do we track visited nodes?**

This prevents repeated processing and stops the search from looping around cycles. My BFS marks nodes as visited when they enter the queue.

**Which path does BFS take in the adjusted graph? Why?**

It takes A -> C -> F -> I. BFS explores nodes layer by layer, so it finds a path with the fewest edges. This path has three edges.

**What is the complexity of BFS?**

The worst-case time complexity is O(|V| + |E|). |V| is the number of vertices and |E| is the number of edges. BFS processes each reachable node once and examines its edges.

### Task 3 - DFS

**Which algorithm finds I sooner in the initial graph?**

With my neighbour order, DFS checks four nodes, while BFS checks nine. The stack explores the C branch first and reaches I directly.

**Which algorithm finds I sooner in the adjusted graph?**

With the same neighbour order, DFS checks five nodes, while BFS would still check nine. However, DFS takes A -> C -> F -> H -> I, which is longer than the shortest path. These node counts do not measure actual runtime.

**Why do BFS and DFS have the same complexity?**

Both have a worst-case time complexity of O(|V| + |E|), because both may need to examine every reachable node and edge. Their visiting order differs, so one may find a particular target earlier. This depends on the graph, target and neighbour order.