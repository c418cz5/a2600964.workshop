## Prac B Reflections

### Task 1: File I/O

- File.CreateText overwrites existing contents. With the File.Exists check, my existing file was left unchanged.
- The @ symbol creates a verbatim string, so backslashes are treated literally.
- using disposes the reader or writer, closing the file and flushing the writer. Otherwise, I need to call Close or Dispose myself.
- StreamReader can read one line at a time. File.ReadAllText loads the whole file into one string and closes the file automatically.

### Task 2: JSON

- The ! after Deserialize suppresses the compiler's nullable warning. It does not check for null at runtime.
- Non-public properties are ignored by default. Making the Player properties public allowed all four properties to be saved.

### Task 3: Generic Methods

- where T : class means T must be a reference type, such as List<Player> or LinkedList<Player>. This lets both collections use the same file methods.

### Task 4: Memory Usage

- The Garbage Collector reclaims memory from managed objects that are no longer reachable.
- The runtime and GC manage heap allocations, so they can report heap information.
- GC.Collect() forces a garbage collection. Objects that are still reachable remain in memory.
- PeakWorkingSet64 was higher because it measures the whole process's peak physical memory. HeapSizeBytes reports the managed heap size at the last collection.

### Task 5: List and LinkedList

Both runs successfully loaded 10,000 players.

| Collection | HeapSizeBytes | PeakWorkingSet64 |
|---|---:|---:|
| List | 10,572,112 | 41,316,352 |
| LinkedList | 11,274,176 | 42,528,768 |

List used less memory in this test. List stores player references in an array, while LinkedList creates extra nodes with next and previous links.

These are whole-program measurements. Both the original and loaded collections were kept alive during each measurement.
