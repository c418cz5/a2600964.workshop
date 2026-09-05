# Topic 5 Prac B Reflection
## 1. LinkedList<T> and List<T>
From this week's lesson, I learned that:
List<T> can be accessed via index (e.g., [3]).
LinkedList<T> uses nodes and references and cannot be accessed directly by index.
List<T> is faster for looking up elements at a specific position.
LinkedList<T> makes insertion and deletion more convenient when the node is already known.

## 2. Initialising a LinkedList
`List<T>` has an `Add()` method, so it supports collection initializer syntax.
`LinkedList<T>` typically uses `AddFirst()`, `AddLast()`, or nodes to add elements.
Therefore, I cannot directly use the `["Why", "isn't", ...]` syntax used for `List`.

## 3. Accessing LinkedList elements
I discovered that `LinkedList<T>` does not have an indexer like `Array` or `List`.
So, I have to start from the first node and access elements one by one using `.Next`.
Accessing the third or fifth element requires traversing the preceding nodes.

After modifying Rick's age, Rick's age changed in both collections because the List and the LinkedList store references to the same Person object.