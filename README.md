# Spider Navigation System - SNS

- **Repository**

Node.js: https://github.com/kukuu/spider-navigation-system/tree/main/nodejs

C#: https://github.com/kukuu/spider-navigation-system/tree/main/csharp


- **Technical Implementation Overview**
  
The SNS implements a grid-based coordinate system with stateful spider entities that process sequential movement instructions. The core algorithm uses finite state machines for orientation management, where each spider maintains its position (x, y) and direction (Up, Right, Down, Left) as discrete states. Movement operations involve coordinate transformations based on current orientation while boundary checking prevents spiders from moving beyond the defined wall dimensions. The instruction parser processes character sequences into executable commands, with the navigation service orchestrating the complete workflow from input parsing to final position calculation. 
 
- **Key Challenges & Risk Factors**

Primary technical challenges include coordinate system boundary management, where spiders could potentially move outside grid boundaries—mitigated through precondition checks before each movement operation. State transition complexity presents another risk, as incorrect orientation changes could lead to invalid positions; this is addressed through comprehensive unit testing covering all turn combinations. Input validation posed significant risks, with malformed data potentially crashing the system, mitigated through robust parsing with exception handling and data sanitization. Performance considerations for large instruction sets were addressed through efficient O(n) algorithms that process instructions sequentially without unnecessary computational overhead.

- **Execution & Validation**
  
To execute the solution, run:

```
npm start
```
 for Node.js or 
 
 ```
dotnet run
```
for C# from their respective directories. The system includes built-in visualization showing the spider's complete path using ASCII art, with directional arrows mapping each movement step. 

Comprehensive test suites validate all edge cases including boundary conditions, invalid inputs, and complex navigation sequences. The modular architecture allows easy extension for multiple spiders or additional movement commands while maintaining system reliability through separation of concerns between parsing, navigation, and visualization components.

Both **NodeJS** and **C#** implementations are provided for sake of versatility.

- **Folder Structure**

```
spider-navigation/
├── nodejs/
│   ├── src/
│   │   ├── models/
│   │   │   └── Spider.js
│   │   ├── services/
│   │   │   └── NavigationService.js
│   │   ├── utils/
│   │   │   ├── InputParser.js
│   │   │   ├── Validation.js
│   │   │   └── Visualiser.js          ← 3 FILES IN UTILS
│   │   └── index.js                   ← ONLY NEW ADDITION
│   ├── tests/
│   │   └── spider.test.js
│   ├── package.json
│   └── README.md
├── csharp/
│   ├── SpiderNavigation/
│   │   ├── Models/
│   │   │   └── Spider.cs
│   │   ├── Services/
│   │   │   └── NavigationService.cs
│   │   ├── Utils/
│   │   │   └── InputParser.cs
│   │   ├── Program.cs
│   │   └── SpiderNavigation.csproj
│   ├── Tests/
│   │   ├── SpiderTests.cs
│   │   └── SpiderNavigation.Tests.csproj
│   └── README.md
└── README.md
```

- **Deployment Architecture**

This architecture ensures separation of concerns, testability, maintainability, and scalability while following enterprise-grade software design principles.

```
┌─────────────────────────────────────────────────────────────┐
│                    PRODUCTION ENVIRONMENT                   │
├─────────────────┐    ┌─────────────────┐    ┌───────────────┤
│   LOAD          │    │   APPLICATION   │    │   MONITORING  │
│   BALANCER      │    │   SERVERS       │    │   & LOGGING   │
│                 │    │                 │    │               │
│ • Traffic       │    │ • Node.js       │    │ • Metrics     │
│   Distribution  │───▶│   Instances     │───▶│ • Alerts      │
│ • SSL           │    │ • C# Services   │    │ • Dashboards  │
│   Termination   │    │ • API Endpoints │    │               │
└─────────────────┘    └─────────────────┘    └───────────────┘
                                │
                                ▼
                       ┌─────────────────┐
                       │   DATA STORE    │
                       │                 │
                       │ • Redis Cache   │
                       │ • File Storage  │
                       │ • Session Data  │
                       └─────────────────┘
```

- **Key Features**

✅ Clean architecture with separation of concerns

✅ Comprehensive unit tests

✅ ASCII visualization of navigation path

✅ Error handling and validation

✅ Readable, maintainable code

✅ Proper documentation

- **Outcome**

Both solutions produce the exact same output and follow the same architectural principles. The visualization shows each step of the spider's journey with directional arrows and marks the final position with a star (★)


- **Execution Commands**

_Nodejs Execution Commands_:

```
cd nodejs

# Install dependencies
npm install

# Run the application
npm start

# Run tests
npm test

# Run tests in watch mode
npm run test:watch

```
_Expected Output:_
```

🕷️  SPIDER NAVIGATION SYSTEM

Input:
Wall: 7 15
Spider: 4 10 Left
Instructions: FLFLFRFFLF

📊 FINAL RESULT:
Expected: 5 7 Right
Actual: 5 7 Right

🕸️  NAVIGATION PATH VISUALIZATION:

· · · · · · · · 
· · · · · · · · 
· · · · · · · · 
· · · · · ★ · · 
· · · · → → → · 
· · · ← · · · · 
· · · ↑ · · · · 
· · · ↑ · · · · 
· · · ↑ · · · · 
· · · ↑ · · · · 
· · · ← ← ← · · 
· · · · · · · · 
· · · · · · · · 
· · · · · · · · 
· · · · · · · · 
· · · · · · · · 

📈 PATH STEPS:
Step 0: (4, 10) facing Left
Step 1: (3, 10) facing Left
Step 2: (3, 10) facing Down
Step 3: (3, 9) facing Down
Step 4: (3, 9) facing Right
Step 5: (4, 9) facing Right
Step 6: (4, 9) facing Up
Step 7: (4, 10) facing Up
Step 8: (4, 10) facing Right
Step 9: (5, 10) facing Right
Step 10: (5, 10) facing Down
Step 11: (5, 9) facing Down
Step 12: (5, 8) facing Down
Step 13: (5, 7) facing Down
Step 14: (5, 7) facing Right

```

_c# Execution Commands_:

🚀 RUNNING C# SOLUTION

In VS Code Terminal:

```
cd csharp/SpiderNavigation

# Build and run

dotnet run

# Run tests

cd ../Tests

dotnet test
```


## Execution Sequence & Comparative Analysis
Both implementations follow identical execution sequences: 

```
input parsing → entity instantiation → instruction processing → result output

```
Node.js excels in rapid prototyping with dynamic typing and npm ecosystem integration, executed via npm start after dependency installation with npm install.

C# provides superior performance and type safety, run using dotnet run after solution restoration with dotnet restore. 

The Node.js version offers faster development cycles while C# delivers better runtime efficiency and compile-time error detection, with both producing identical navigation results and visualization outputs despite their differing runtime characteristics and ecosystem dependencies.
