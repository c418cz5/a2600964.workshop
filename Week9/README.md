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

## Prac B

### Task 1 - Dijkstra's Algorithm

**How does the algorithm work?**

I set the starting distance to 0 and other distances to a very large value. The priority queue selects the node with the lowest known cost. When I find a cheaper route to a neighbour, I update its distance and parent. Finally, I follow the parents backwards and reverse the path. The horse graph gives a total cost of 10.

**What is its complexity compared with BFS and DFS?**

Standard heap-based Dijkstra is O((V + E) log V), while BFS and DFS are O(V + E). Dijkstra does extra work to maintain priorities.

My simplified Task 1 loop can process outdated queue entries again, so its worst case can increase to O(VE). The AI version checks and skips these entries.

### Task 2 - AI Code Comparison

**What AI tool did I use?**

I used ChatGPT (Codex). It helped me follow the workshop steps and generated a separate version for comparison.

**What prompts did I use?**

I provided the workshop instructions and asked to continue Prac B. My follow-up questions included what AI code meant and why the program still printed "Hello, World!".

**How many rounds were needed?**

One algorithm-generation round was enough. I needed follow-up help to save the code in the correct Program.cs file. No algorithm changes were needed.

**How was the AI version different?**

My learning version follows the workshop steps using Node and Graph classes. The AI version uses strings and tuples, and puts the search inside a FindShortestPath method.

**What did the AI version do better?**

It skips outdated queue entries to avoid repeated work. Its search method can also be called again with different starting and target nodes.

**What did the AI version do worse?**

As a beginner, I find its tuple syntax, LINQ and nested dictionary types harder to understand. The workshop version is easier for me to follow step by step.

### Task 3 - Semester Reflection

**What was my favourite C# feature?**

LINQ, because it makes filtering and sorting collections shorter and clearer.

**What was my least favourite C# feature?**

Nullable types and null warnings were confusing. I needed more practice to understand when to use `?`.

**What was the easiest topic?**

Stacks and queues. The undo history and printer queue examples helped me understand their processing orders.

**What was the most fun topic?**

Graphs and pathfinding. Finding a route around the bees made the algorithm feel more practical.

**What will I revise before the exam?**

BFS, DFS, Dijkstra and their time complexities. I want to practise tracing the algorithms by hand.

**What advice would I give new students?**

Run small changes regularly and commit after each task. Check the project folder and Program.cs path carefully.

**What could improve the course?**

More step-by-step diagrams showing how the queue, stack and priority queue change during a search would help.