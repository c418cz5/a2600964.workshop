# Week 8 Reflection

Student: Weiyu Liu

Student ID: a2600964

## Prac A Reflections

### Task 1 - Hashtable

**What happened when I added a string key? Why?**

The string key was added successfully, even though the other keys were Player objects. Hashtable stores keys and values as objects, so it does not require every key to be a Player.

This showed me why a generic collection such as Dictionary<Player, int> can be safer when the expected types are known.

**What happened when I added a duplicate key?**

Adding the same Player object as a key again caused an ArgumentException. My try-catch printed the error message, and the existing score was not replaced.

**Could I use LINQ for sorting?**

Yes. I first used Cast<DictionaryEntry>() and then OrderByDescending() to sort the entries by score.

Hashtable provides a non-generic sequence. Cast supplied the element type needed by the sorting query. I also checked whether each key was a Player before printing its Name.

**Evidence:** [Hashtable code](Topic8A/HashtableDemo.cs) | [Screenshots](Screenshots/)

### Task 2 - String Performance Benchmark

**Which approach was faster?**

StringBuilder was faster in my saved run. Both methods appended 100,000 characters and produced the same final length.

| Method | Elapsed time in the saved run | Final length |
|---|---:|---:|
| String concatenation using += | 660.88 ms | 100,000 |
| StringBuilder.Append | 0.67 ms | 100,000 |

These are results from one run, so the exact times can change on another run or computer.

**Why was StringBuilder faster?**

Strings are immutable. Each += operation creates a new string and copies the previous contents. As the string becomes longer, each later operation has more characters to copy.

StringBuilder uses mutable buffers, so it can append characters without copying the entire previous result every time. This reduces repeated copying and allocation work.

**Evidence:** [Benchmark code](Topic8A/ComplexityDemo.cs) | [Saved output screenshots](Screenshots/)

### Task 3 - Graphing the Results

I used 20 passes. Pass 1 appended 10,000 characters, and each later pass added another 10,000 to the input size. Pass 20 therefore appended 200,000 characters.

Both graphs use milliseconds. In the complexity explanations below, n means the number of characters appended in one pass.

**What is the Big-O complexity of repeated string concatenation?**

Repeated string concatenation in this loop is O(n²). Each new string needs to copy the characters already added, so the total copying work grows faster than the number of appended characters.

**How does the evidence support this?**

The string concatenation graph becomes steeper as the pass number increases. Larger inputs take much more time, which is consistent with quadratic growth.

The measurements have some variation, but the overall trend shows that this approach scales poorly.

**What is the Big-O complexity of the StringBuilder method?**

Building n characters with StringBuilder is O(n) overall. Appending normally adds to a buffer, so the program avoids repeatedly copying the whole result.

**How does the evidence support this?**

The StringBuilder graph is roughly linear and its measured times are much smaller. There is a spike around pass 16, but the overall pattern still grows much more slowly than the string concatenation graph.

Short measurements can be affected by background activity and measurement noise. The graph supports the explanation from the code, but it does not prove the complexity by itself.

**What did I learn about benchmarking?**

My code clears and reuses the StringBuilder between passes, which can reduce allocation work. The graphs describe this particular implementation.

I learned to check input sizes, time units and how objects are reused before comparing results. Repeating the measurements would give more reliable evidence.

**Evidence:** [Graphing code](Topic8A/GraphingDemo.cs) | [String concatenation graph](Screenshots/appendPlot.png) | [StringBuilder graph](Screenshots/buildPlot.png)

### Overall Prac A Reflection

This practical helped me connect data structures with type safety and performance. A program can produce the correct result but still do unnecessary work. Looking at the code, checking the output and measuring larger inputs gave me a better understanding of the differences.

## Prac B Reflections

### Task 1 - File I/O

- File.CreateText overwrites existing contents. With the File.Exists check, my existing file was left unchanged.
- The @ symbol creates a verbatim string, so backslashes are treated literally.
- using disposes the reader or writer, closing the file and flushing the writer. Otherwise, I need to call Close or Dispose myself.
- StreamReader can read one line at a time. File.ReadAllText loads the whole file into one string and closes the file automatically.

### Task 2 - JSON

- The ! after Deserialize suppresses the compiler's nullable warning. It does not check for null at runtime.
- Non-public properties are ignored by default. Making the Player properties public allowed all four properties to be saved.

### Task 3 - Generic Methods

- where T : class means T must be a reference type, such as List<Player> or LinkedList<Player>. This lets both collections use the same file methods.

### Task 4 - Memory Usage

- The Garbage Collector reclaims memory from managed objects that are no longer reachable.
- The runtime and GC manage heap allocations, so they can report heap information.
- GC.Collect() forces a garbage collection. Objects that are still reachable remain in memory.
- PeakWorkingSet64 was higher because it measures the whole process's peak physical memory. HeapSizeBytes reports the managed heap size at the last collection.

### Task 5 - List and LinkedList

Both runs successfully loaded 10,000 players.

| Collection | HeapSizeBytes | PeakWorkingSet64 |
|---|---:|---:|
| List | 10,572,112 | 41,316,352 |
| LinkedList | 11,274,176 | 42,528,768 |

List used less memory in this test. List stores player references in an array, while LinkedList creates extra nodes with next and previous links.

These are whole-program measurements. Both the original and loaded collections were kept alive during each measurement.
