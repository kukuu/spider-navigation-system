using SpiderNavigation.Models;
using SpiderNavigation.Services;
using SpiderNavigation.Utils;
using System;

namespace SpiderNavigation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Spider Navigation System ===");
            Console.WriteLine();

            try
            {
                // Get wall dimensions
                Console.Write("Enter wall dimensions (format: 'width height' e.g., '7 15'): ");
                var dimensionsInput = Console.ReadLine();
                var (maxX, maxY) = InputParser.ParseWallSize(dimensionsInput);

                // Get spider initial position
                Console.Write("Enter spider initial position (format: 'x y orientation' e.g., '4 10 Left'): ");
                var positionInput = Console.ReadLine();
                var (startX, startY, orientation) = InputParser.ParseSpiderPosition(positionInput);

                // Get instructions
                Console.Write("Enter movement instructions (e.g., 'FLFLFRFFLF'): ");
                var instructionsInput = Console.ReadLine();
                var instructions = InputParser.ParseInstructions(instructionsInput);

                // Create spider and navigate
                var spider = new Spider(startX, startY, orientation, maxX, maxY);
                var navigationService = new NavigationService();
                var finalPosition = navigationService.Navigate(spider, instructions);

                // Display result
                Console.WriteLine();
                Console.WriteLine("=== Final Position ===");
                Console.WriteLine(finalPosition.GetFinalPosition());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
