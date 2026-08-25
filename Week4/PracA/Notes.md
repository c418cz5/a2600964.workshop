# Topic 4 Prac A Reflection

## 1. Which item was incorrect?

In my run, the second number, 77, was the first value that caused a problem. The program used fixed character positions with `Substring()`. It read 23 correctly, but then it read spaces and a line break instead of the next number.

The problem was not really the number itself. The problem was the way the program read the input. Some other values could look correct when their positions happened to match, but this method was not reliable.

## 2. What was wrong with the symbols list?

The symbols were read with extra spaces and the Windows line ending `\r`. For example, the symbol was not exactly `"*"`. It could be something like `" * \r"`.

Because of this, comparing the symbol with `"*"` did not work correctly. I used `Trim()` to remove the extra spaces and line endings.

## 3. How did the debugger help?

I put a breakpoint on the line that used `int.Parse()` and stepped through the program with `F10`.

The Locals window showed that the first value was 23. On the next loop, the substring contained spaces instead of a number. This helped me find that the fixed `Substring()` calculation was causing the problem.

## 4. Three warnings or problems that I fixed

First, I stopped using fixed character positions and split the input into lines instead. This made the program easier to understand.

Second, I used `string.IsNullOrEmpty()` instead of comparing strings with `""`.

Third, I used `CultureInfo.InvariantCulture` with `int.Parse()`. This makes the number conversion more predictable.

I also added a namespace and changed the class to internal because this is a small console application.

## 5. Three warnings or suggestions that I did not fix

I did not create resource files for the console messages from the `CA1303` warnings. This would be useful for a large program with different languages, but it is unnecessary for this small exercise.

I kept the `BrokenProgram` class and the `Main()` method instead of changing the program to top-level statements. The class structure was provided in the task and was useful when using the debugger.

I did not change the original input data. The task specifically said not to change the `input` variable, so I fixed the way it was read instead.
