
//Main Entry Point
using SpiderNavigation.Models;
using SpiderNavigation.Services;
using SpiderNavigation.Utils;

class Program
{
    static void Main()
    {
        Console.WriteLine("🕷️  SPIDER NAVIGATION SYSTEM\n");
        
        // Input data
        string wallInput = "7 15";
        string spiderInput = "4 10 Left"; 
        string instructionsInput = "FLFLFRFFLF";
        
        Console.WriteLine("Input:");
        Console.WriteLine($"Wall: {wallInput}");
        Console.WriteLine($"Spider: {spiderInput}");
        Console.WriteLine($"Instructions: {instructionsInput}\n");
        
        try
        {
            var wallSize = InputParser.ParseWallSize(wallInput);
            var spiderPosition = InputParser.ParseSpiderPosition(spiderInput);
            var instructions = InputParser.ParseInstructions(instructionsInput);
            
            var spider = NavigationService.Navigate(wallSize, spiderPosition, instructions);
            
            Console.WriteLine("📊 FINAL RESULT:");
            Console.WriteLine($"Expected: 5 7 Right");
            Console.WriteLine($"Actual: {spider.GetFinalPosition()}");
            
            Visualizer.DisplayPath(spider.Path, wallSize.Width, wallSize.Height);
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error: {ex.Message}");
        }
    }
}