# COMP2021 Workshop Portfolio

**Student:** Weiyu Liu  
**Student ID:** a2600964  
**Course:** COMP2021 Software Development Practice  
**Study Period:** Semester 2, 2026

## About This Portfolio

This is my workshop portfolio for COMP2021 Software Development Practice. It includes my C# practical work from Topic 1 to Topic 9, with code, tests, screenshots and reflection notes.

Before this course, I mainly used Python. At the beginning, I was not familiar with C# syntax, static typing and the .NET tools. During this semester, I learned how to write C# classes, use different data structures, debug programs and test my code.

I used Git regularly to save my work and record my progress.

## Repository Structure

| Folder | Description |
|---|---|
| `HelloCSharp/`, `IntroTopic/` | First C# programs and environment practice |
| `Prac1A/`, `Prac1B/` | Topic 1 practical work |
| `Prac1B.Tests/` | Topic 1 xUnit tests |
| `Prac2A/`, `Prac2B/` | Early Payroll and BankAccount exercises |
| `Week2/` | Classes, properties, validation and unit testing |
| `Week3/` | Inheritance and polymorphism |
| `Week4/` | Debugging, code analysis and fixing errors |
| `Week5/` | Arrays, List and LinkedList |
| `Week6/` | Stack, Queue and LINQ |
| `Week7/` | SortedSet, SortedDictionary and PriorityQueue |
| `Week8/` | Complexity, file I/O, JSON and memory |
| `Week9/` | Graphs, BFS, DFS and Dijkstra's algorithm |
| `RecipeManagement-PartA/` | Additional Recipe Management assignment work |
| `screenshots/` | Screenshots from the early practicals |
| `payroll-coverage/`, `bankaccount-coverage/` | Unit test coverage reports |

Each weekly folder contains the related practical projects. Most folders also include notes and screenshots showing the tasks and results.

## Weekly Workshop Progress

### Topic 1 — C# Basics

**Status: Complete**

I started by learning how to create and run C# console applications with the .NET CLI.

I practised variables, control flow, classes, methods, lists and dictionaries. In Prac B, I made a simple Todo Manager and used xUnit to test some methods.

One problem I had was putting the test project inside the main project folder. This caused build errors. I moved the test project to a separate folder and fixed the references.

**Reflection:** [Topic 1 Notes](Topic1-Notes.md)

### Topic 2 — Classes, Properties and Encapsulation

**Status: Complete**

I worked with Payroll and BankAccount classes.

I used private fields, properties, constructors and methods to control how data can be changed. I also practised method overloading with different parameter types.

For Payroll, I added validation to stop negative values and used xUnit tests to check calculations and errors. I also learned how to generate code coverage reports.

I found that `decimal` is more suitable than `double` for money calculations.

**Reflection:** [Topic 2 Prac B Notes](Week2/PracB/Notes.txt)

### Topic 3 — Inheritance and Polymorphism

**Status: Complete**

In Prac A, I used a BankAccount base class with SavingsAccount and CheckingAccount.

In Prac B, I worked with Employee, FullTimeEmployee and Contractor classes. I used inheritance, abstract methods and overriding to calculate different types of pay.

This helped me understand how one base type can work with different derived classes.

**Reflections:** [Prac A](Week3/PracA/Notes.md) | [Prac B](Week3/PracB/Notes.md)

### Topic 4 — Debugging and Code Quality

**Status: Complete**

This topic focused on finding errors and making code easier to understand.

I used breakpoints, the debugger and the Locals window to inspect variables. I found problems with fixed `Substring()` positions and extra spaces in input data.

I also practised checking compiler warnings and code analysis suggestions. In Prac B, I worked with a grid-processing problem and recorded the issues I found.

I learned that testing small parts of a program can make debugging easier.

**Reflections:** [Prac A](Week4/PracA/Notes.md) | [Prac B](Week4/PracB/Notes.md)

### Topic 5 — Arrays, Lists and Linked Lists

**Status: Complete**

I compared arrays, `List<T>` and `LinkedList<T>`.

I practised adding, removing and reading items. I also worked with a Person class and observed how the same object can be referenced by different collections.

I learned that a List supports index access, while a LinkedList uses nodes and links between them.

**Reflections:** [Prac A](Week5/PracA/Notes.md) | [Prac B](Week5/PracB/Notes.md)

### Topic 6 — Stack, Queue and LINQ

**Status: Complete**

In Prac A, I worked with Stack and Queue operations.

I practised LIFO and FIFO, converting a Stack to a Queue and sorting accounts using Queue operations.

In Prac B, I started using LINQ methods such as `Where()`, `Select()` and `OrderBy()`.

At first, lambda expressions were confusing, but after some practice I found LINQ easier to read than writing multiple loops for filtering and sorting.

**Reflection:** [Topic 6 Reflection](Week6/Reflection.md)

### Topic 7 — Sorted Collections and Priority Queues

**Status: Complete**

I used `SortedSet<T>` to keep values in sorted order and prevent duplicates.

I also created custom comparers for BankAccount and score objects. This helped me understand why C# needs rules for comparing custom types.

In Prac B, I used `SortedDictionary` and `PriorityQueue` for leaderboard and priority-based examples.

I also used ScottPlot to create a bar chart of account balances.

**Reflection:** [Topic 7 Reflection](Week7/README.md)

### Topic 8 — Complexity, File I/O and Memory

**Status: Complete**

I practised using a Hashtable and looked at algorithm complexity and performance graphs.

In Prac B, I worked with text files, JSON serialization and generic methods.

I also compared memory usage between `List<T>` and `LinkedList<T>` using a collection of 10,000 players.

In my test, List used less memory because LinkedList needs extra nodes and references. I learned that different collections have different memory costs.

**Reflection:** [Topic 8 Reflection](Week8/README.md)

### Topic 9 — Graphs and Pathfinding

**Status: Complete**

In Prac A, I created graphs and practised Breadth-First Search (BFS) and Depth-First Search (DFS).

I learned that BFS explores nodes level by level, while DFS follows one branch before going back.

In Prac B, I used Dijkstra's algorithm with a priority queue to find a low-cost route through a weighted graph.

I also completed the workshop AI code comparison activity and compared the different approaches.

This was one of my favourite topics because I could see how data structures are used to solve pathfinding problems.

**Reflection:** [Topic 9 Reflection](Week9/README.md)

## How to Run the Projects

**Requirements:**

- .NET SDK 10.0
- A terminal such as PowerShell or the VS Code terminal
- Git for version control

Open the repository folder in your terminal.

For example, to run the Week 6 Stack demonstration:

```powershell
dotnet run --project Week6/StackDemo/StackDemo.csproj
```

To run the Week 9 graph demonstration:

```powershell
dotnet run --project Week9/Topic9A/Topic9A.csproj
```

To run an xUnit test project:

```powershell
dotnet test Week3/PracA.Tests/PracA.Tests.csproj
```

Other console and test projects can be run with their own `.csproj` file paths.

Some projects use extra NuGet packages, so the first build may need to restore dependencies.

## Reflection and Learning Progress

I think my C# skills improved a lot during this semester.

At the start, I often mixed Python and C# syntax. I also had problems with project references, nullable types and compiler errors. These problems helped me understand how C# projects are organised.

Later, I became more familiar with classes, collections, LINQ and unit testing. I learned that different data structures have different strengths, so I should choose them based on what the program needs.

The most interesting topics for me were LINQ and graph algorithms. I also want to practise complexity analysis more because I sometimes find it difficult to compare algorithms without running them.

I tried to commit and push my work regularly instead of uploading everything at the end. The Git history, screenshots and weekly reflections show how I worked through the practical tasks.

## Tools Used

- C# and .NET SDK
- Visual Studio Code
- Git and GitHub
- xUnit for unit testing
- ScottPlot for charts
- .NET CLI and PowerShell

## Final Reflection

This portfolio records my progress from basic C# programs to more difficult data structures and algorithms.

I still need more practice, especially with algorithm analysis and writing code without looking at examples. However, I now feel more confident reading C# code, using collections, debugging problems and writing tests.

I will continue practising these skills in future software development projects.
