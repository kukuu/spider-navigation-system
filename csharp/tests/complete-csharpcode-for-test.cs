using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== SPIDER NAVIGATION ===");
        
        // Correct test case from specification
        int maxX = 7, maxY = 15;
        int startX = 4, startY = 10;
        string startOrientation = "Left";
        string instructions = "FLFLFRFFLF"; // CORRECT INSTRUCTIONS
        
        var spider = new Spider(startX, startY, startOrientation, maxX, maxY);
        
        Console.WriteLine($"Wall: {maxX}x{maxY}");
        Console.WriteLine($"Start: {spider.GetFinalPosition()}");
        Console.WriteLine($"Instructions: {instructions}");
        Console.WriteLine();
        
        // Process each instruction
        foreach (char instruction in instructions)
        {
            string before = spider.GetFinalPosition();
            
            if (instruction == 'L') spider.TurnLeft();
            else if (instruction == 'R') spider.TurnRight();
            else if (instruction == 'F') spider.MoveForward();
            
            Console.WriteLine($"{instruction}: {before} -> {spider.GetFinalPosition()}");
        }
        
        string result = spider.GetFinalPosition();
        Console.WriteLine();
        Console.WriteLine($"Final: {result}");
        Console.WriteLine($"Expected: 5 7 Right");
        Console.WriteLine($"Test: {(result == "5 7 Right" ? "✅ PASS" : "❌ FAIL")}");
    }
}

public class Spider
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Orientation { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }

    public Spider(int x, int y, string orientation, int maxX, int maxY)
    {
        X = x;
        Y = y;
        Orientation = orientation;
        MaxX = maxX;
        MaxY = maxY;
    }

    public void TurnLeft()
    {
        Orientation = Orientation switch
        {
            "Up" => "Left",
            "Left" => "Down", 
            "Down" => "Right",
            "Right" => "Up",
            _ => Orientation
        };
    }

    public void TurnRight()
    {
        Orientation = Orientation switch
        {
            "Up" => "Right",
            "Right" => "Down",
            "Down" => "Left", 
            "Left" => "Up",
            _ => Orientation
        };
    }

    public void MoveForward()
    {
        switch (Orientation)
        {
            case "Up": if (Y < MaxY) Y++; break;
            case "Right": if (X < MaxX) X++; break;
            case "Down": if (Y > 0) Y--; break;
            case "Left": if (X > 0) X--; break;
        }
    }

    public string GetFinalPosition() => $"{X} {Y} {Orientation}";
}