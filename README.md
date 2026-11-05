# COMP2021 Workshop Portfolio

**Student:** Weiyu Liu  
**Student ID:** a2600964  
**Course:** COMP2021 Software Development Practice  
**Study Period:** Semester 2, 2026

## About This Portfolio

This is my personal workshop portfolio for COMP2021. It contains my Topic 1–9 practical work across Modules 1–3, including C# programs, unit tests, screenshots, charts and reflection notes.

Before this course, I mainly used Python. I needed time to become familiar with C# syntax, static typing and the .NET tools. During the semester, I moved from small console programs to classes, collections and graph algorithms. This repository records that learning process, including mistakes, fixes and later improvements.

## Repository Structure

| Location | What it contains |
|---|---|
| [HelloCSharp](HelloCSharp/), [IntroTopic](IntroTopic/), [PayrollCalculator](PayrollCalculator/) | First console programs, environment checks and early payroll calculations |
| [Prac1A](Prac1A/), [Prac1B](Prac1B/) | Topic 1 exercises, Person classes and the Todo Manager |
| [Prac1B.Tests](Prac1B.Tests/) | Person class tests from Topic 1 |
| [Week2](Week2/) | Payroll and BankAccount classes, validation and test projects |
| [Week3](Week3/) | Inheritance, polymorphism, interfaces and related tests |
| [Week4](Week4/) | Debugging, code analysis, XML comments and a grid-processing exercise |
| [Week5](Week5/) | Arrays, lists, linked lists and object references |
| [Week6](Week6/) | Built-in and custom stacks and queues, plus LINQ examples |
| [Week7](Week7/) | Sorted collections, custom comparers, priority queues and a ScottPlot chart |
| [Week8](Week8/) | Hashtable, performance measurements, file I/O, JSON and memory comparisons |
| [Week9](Week9/) | Graphs, BFS, DFS, Dijkstra and the workshop AI comparison |
| [screenshots](screenshots/) and weekly `Screenshots` folders | Saved code, debugging and console-output evidence |

Some early projects were moved into `Week2` and `Week3`. Their older Git commits may use the original root-level paths. The links and commands in this README use the current locations.

The separate [Recipe Management assignment](RecipeManagement-PartA/RecipeManager/README.md) is also stored in this repository. It has its own README and tests.

## Weekly Workshop Progress

### Topic 1 — C# Basics

**Status: Complete**

I created console projects with the .NET CLI and practised variables, methods, classes and exceptions. The Todo Manager uses a list for tasks and a dictionary for tags. I also wrote xUnit tests for the Person class.

**Reflection:** [Topic 1 notes](Topic1-Notes.md)

### Topic 2 — Classes, Properties and Encapsulation

**Status: Complete**

I moved payroll calculations from the main program into a Payroll class. Constructors and validated properties keep related data and behaviour together. I also used a private balance setter and overloaded Deposit methods in BankAccount. Tests check calculations, invalid amounts and insufficient funds.

**Reflection:** [BankAccount notes](Week2/PracB/Notes.txt)

### Topic 3 — Inheritance and Polymorphism

**Status: Complete**

SavingsAccount and CheckingAccount extend BankAccount with different behaviour. Employee, FullTimeEmployee and Contractor helped me practise abstract methods, overriding and the IReportable interface. Storing different employees in one list showed me how polymorphism reduces repeated code.

**Reflections:** [Prac A](Week3/PracA/Notes.md) | [Prac B](Week3/PracB/Notes.md)

### Topic 4 — Debugging and Code Quality

**Status: Complete**

I used breakpoints, stepping and the Locals window to inspect values. Fixed Substring positions and extra whitespace caused input errors, so I changed how the text was read. I also practised XML documentation, compiler warnings and debugging the grid-processing and split-count logic.

**Reflections:** [Prac A](Week4/PracA/Notes.md) | [Prac B](Week4/PracB/Notes.md)

### Topic 5 — Arrays, Lists and Linked Lists

**Status: Complete**

I practised adding, removing and accessing collection items. Arrays have a fixed size, while lists can grow. Linked lists use nodes rather than an indexer. Changing a Person object through one collection also changed what another collection displayed because both held references to the same object.

**Reflections:** [Prac A](Week5/PracA/Notes.md) | [Prac B](Week5/PracB/Notes.md)

### Topic 6 — Stacks, Queues and LINQ

**Status: Complete**

I used undo history and printer jobs to practise LIFO and FIFO. I worked with account collections, converted between collections, and implemented custom stack and queue examples. I then used Where, Select and OrderBy to filter and sort data with LINQ.

**Reflection:** [Topic 6 notes](Week6/Reflection.md)

### Topic 7 — Sorted Collections and Priority Queues

**Status: Complete**

I used SortedSet and SortedDictionary to maintain ordered data. Custom comparers gave BankAccount and score objects a clear comparison rule. I also used integer and enum priorities in a PriorityQueue and created an account-balance chart with ScottPlot.

**Reflection:** [Topic 7 notes](Week7/README.md)  
**Chart:** [Account balances](Week7/Screenshots/Topic7A-Task3.png)

### Topic 8 — Hash Tables, Complexity, File I/O and Memory

**Status: Complete**

I checked Hashtable type safety and duplicate-key behaviour. I measured repeated string concatenation against StringBuilder and graphed the results. File I/O, JSON and generic helpers let me save and reload player collections. I also compared List and LinkedList memory measurements using 10,000 players.

**Reflections and evidence:** [Prac A and Prac B notes](Week8/README.md) | [String concatenation graph](Week8/Screenshots/appendPlot.png) | [StringBuilder graph](Week8/Screenshots/buildPlot.png) | [Data files](Week8/Attachments/)

### Topic 9 — Graphs and Pathfinding

**Status: Complete**

I built Node and Graph classes and searched the graphs using BFS and DFS. Tracking visited nodes prevented repeated processing around cycles. Dijkstra used edge weights and a priority queue to find a route with total cost 10. I also ran a separate AI version and compared its structure and handling of outdated queue entries.

**Reflection:** [Topic 9 notes](Week9/README.md)  
**AI comparison:** [Runnable project](Week9/Topic9B_AI/) | [Code attachment](Week9/Attachments/Topic9B-AI-Dijkstra.cs.txt)

## How to Run

Install the **.NET 10 SDK**. The current projects target `net10.0`.

Open a terminal in the repository root, where this README is located. Use the specific project path because the repository contains several separate projects. The first build may need an internet connection to restore NuGet packages.

### Console Examples

Choose the example you want to run:

| Example | Command from the repository root |
|---|---|
| Todo Manager | `dotnet run --project Prac1B/Prac1B.csproj` |
| Payroll class | `dotnet run --project Week2/PracA/Prac2A.csproj` |
| BankAccount inheritance | `dotnet run --project Week3/PracA/Prac3A.csproj` |
| Stack operations | `dotnet run --project Week6/StackDemo/StackDemo.csproj` |
| LINQ queries | `dotnet run --project Week6/LINQDemo/LINQDemo.csproj` |
| Graph traversal | `dotnet run --project Week9/Topic9A/Topic9A.csproj` |
| Weighted horse graph | `dotnet run --project Week9/Topic9B/Topic9B.csproj` |
| AI comparison version | `dotnet run --project Week9/Topic9B_AI/Topic9B_AI.csproj` |

Both horse-graph versions should produce this route:

```text
Start -> A -> C -> F -> G -> H -> K -> N -> M -> L -> End
Total cost: 10
```

### Charts and File-Based Examples

Run these projects from their own folders so relative paths and output files use the expected location.

To generate the two string-performance charts:

```powershell
cd Week8/Topic8A
dotnet run
cd ../..
```

This saves `appendPlot.png` and `buildPlot.png` in the project folder. Saved assessment copies are in `Week8/Screenshots`. Runtime depends on the computer and input size.

To run the current linked-list memory example:

```powershell
cd Week8/Topic8B
dotnet run
cd ../..
```

This uses the `Week8/Attachments` folder for its JSON file. For the List comparison, select `MemoryBenchmarkDemo.RunList()` in that project's `Program.cs` and run it separately.

The Week 4 Prac B exercise has a local `FileToRead` path in [Program.cs](Week4/PracB/Program.cs). When using another computer or folder, update it to the location of [Example.txt](Week4/PracB/Example.txt) before running that exercise.

### Selecting Earlier Tasks

Some projects currently run the last task completed:

| Project | Current default |
|---|---|
| `Week7/Topic7B` | Enum-priority queue demonstration |
| `Week8/Topic8A` | String concatenation and StringBuilder graphs |
| `Week8/Topic8B` | LinkedList memory benchmark |
| `Week9/Topic9A` | DFS on the initial and adjusted graphs |

Earlier demonstrations remain in their source files. Select the relevant method in the project's `Program.cs` to run another task. The screenshots and Git history also keep the earlier results.

## Testing and Evidence

The automated tests focus on the early class and OOP exercises:

| Test project | Main checks |
|---|---|
| [Prac1B.Tests](Prac1B.Tests/) | Person names and adult-age checks |
| [Week2/PracA.Tests](Week2/PracA.Tests/) | Payroll calculations, tax changes and invalid negative values |
| [Week2/PracB.Tests](Week2/PracB.Tests/) | Deposit overloads, withdrawals and invalid amounts |
| [Week3/PracA.Tests](Week3/PracA.Tests/) | Account inheritance, interest, fees and displayed information |
| [Week3/PracB.Tests](Week3/PracB.Tests/) | Employee pay, polymorphism and interface reports |

Run them individually from the repository root:

```powershell
dotnet test Prac1B.Tests/Prac1B.Tests.csproj
dotnet test Week2/PracA.Tests/Prac2A.Tests.csproj
dotnet test Week2/PracB.Tests/Prac2B.Tests.csproj
dotnet test Week3/PracA.Tests/PracA.Tests.csproj
dotnet test Week3/PracB.Tests/PracB.Tests.csproj
```

For a coverage collection example:

```powershell
dotnet test Week2/PracA.Tests/Prac2A.Tests.csproj --collect:"XPlat Code Coverage"
```

Later exercises are also checked through console output, saved screenshots, charts and data files. For example, I checked duplicate handling in sorted collections, compared performance at different input sizes, and checked graph routes against the expected result. These checks have a different purpose from unit tests.

Evidence folders include [early screenshots](screenshots/), [Week 7 screenshots](Week7/Screenshots/), [Week 8 screenshots](Week8/Screenshots/) and [Week 9 screenshots](Week9/Screenshots/). Memory and timing figures describe the recorded runs, rather than fixed values for every computer.

## Reflection and Learning Progress

My main progress was learning to explain why the code works, rather than only getting output on the screen.

- **Project setup:** I first created a test project inside the application folder, which caused duplicate assembly and reference errors. Moving it beside the application and fixing the reference solved the problem.
- **Object-oriented design:** Moving calculations into classes made the main program shorter. Validation and private setters helped me control changes to data, while tests checked both normal and invalid inputs.
- **Choosing collections:** I became more careful about ordering, duplicates and access patterns. An index, a queue, a set and a linked-list node solve different problems.
- **Algorithms and performance:** BFS finds a path with the fewest edges in an unweighted graph. DFS follows branches, while Dijkstra handles non-negative edge costs. The timing and memory exercises helped me connect these choices with their resource costs.
- **Debugging my workflow:** I sometimes edited the wrong Program.cs or ran Git from the wrong folder. Checking the project path, using `--project`, and reading `git status` and `git diff` helped me find the problem.

The collection and memory exercises also helped me prepare for learning C++. I am more aware of object references, extra linked-list nodes and the cost of copying data. I still need more practice with lower-level memory management.

### Git Practice

I committed practical tasks and later fixes progressively. Most work was done on `main`, with separate commits for code, evidence and reflection updates. Earlier errors and revisions are part of the history.

To inspect the development history:

```powershell
git log --oneline --all
git log --follow --oneline -- Week2/PracA/Payroll.cs
```

The second command follows the Payroll file across its move into the weekly folder. This helps show the earlier work as well as the current location.

## Tools Used

- C# and .NET SDK 10
- Visual Studio Code and its debugger
- Git and GitHub
- xUnit, coverlet and ReportGenerator
- ScottPlot
- .NET CLI and PowerShell

## Final Reflection

I started this course with more experience in Python than C#. I now feel more confident creating classes, choosing collections, debugging errors and writing tests. LINQ and graph pathfinding were especially interesting because I could see practical uses for them.

I still need to practise complexity analysis and writing algorithms without depending too much on examples. My next step is to trace the searches by hand and explain the time and memory choices in my own words.
