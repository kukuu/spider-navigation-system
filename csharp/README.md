# C# Implementation Technical Approach
The C# solution employs object-oriented principles with record types for immutable data structures and switch expressions for concise state transitions. The architecture leverages .NET 6's top-level statements and implicit usings for clean entry points while maintaining strong typing through positional records. 

Technical implementation includes xUnit testing framework, comprehensive exception handling with custom error types, and efficient memory management through structured disposal patterns. Execution flows through parsed input validation, spider entity instantiation with grid boundary injection, and instruction execution with position tracking, culminating in ASCII grid visualization rendered through nested loop constructs.

##  Test Steps

- Step 1: Clone and Navigate

```
git clone https://github.com/kukuu/spider-navigation-system.git
cd spider-navigation-system/csharp

```

- Step 2: Run Tests

```
dotnet test Tests/SpiderNavigation.Tests.csproj

```

- Step 3: Run Interactive Console

```
dotnet run --project SpiderNavigation

```


Step 4: Interactive Input (Type these when prompted)

```
Enter wall dimensions (format: 'width height' e.g., '7 15'): 7 15
Enter spider initial position (format: 'x y orientation' e.g., '4 10 Left'): 4 10 Left
Enter movement instructions (e.g., 'FLEEREFLF'): FLEEREFLF
```

- Step 5: Expected Output

```
=== Final Position ===
5 7 Right

Press any key to exit...
```
