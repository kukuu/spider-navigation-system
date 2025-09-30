# C# Implementation Technical Approach
The C# solution employs object-oriented principles with record types for immutable data structures and switch expressions for concise state transitions. The architecture leverages .NET 6's top-level statements and implicit usings for clean entry points while maintaining strong typing through positional records. 

Technical implementation includes xUnit testing framework, comprehensive exception handling with custom error types, and efficient memory management through structured disposal patterns. Execution flows through parsed input validation, spider entity instantiation with grid boundary injection, and instruction execution with position tracking, culminating in ASCII grid visualization rendered through nested loop constructs.

## Steps to Run the C# Application

- Step 1: Navigate to C# Folder

```
cd spider-navigation-system/csharp
```

- Step 2: Run the Application
```
dotnet run --project SpiderNavigation

```
- Step 3: Enter Input When Prompted

```
=== Spider Navigation System ===

Enter wall dimensions (format: 'width height' e.g., '7 15'): 
```

when you see:

```
=== Spider Navigation System ===

Enter wall dimensions (format: 'width height' e.g., '7 15'): 
```

Type:

```
7 15 and press Enter
```

When you see:

```
Enter spider initial position (format: 'x y orientation' e.g., '4 10 Left'): 

```

Type: 

```
 4 10 Left and press Enter
```


When you see:


```

Enter movement instructions (e.g., 'FLFLFRFFLF'):

```

Type:

```
FLFLFRFFLF and press Enter

```
- Step 4: See the Result

You'll get:

```
=== Final Position ===
5 7 Right

Press any key to exit...
```
##  Test Steps

### Run Interactive Console:

```
cd csharp
dotnet run --project SpiderNavigation

```

- Sample Input:

```
7 15
4 10 Left
FLFLFRFFLF
```

- Expected Output:

```

5 7 Right

```
### Run Tests:

```
cd csharp
dotnet test
```
