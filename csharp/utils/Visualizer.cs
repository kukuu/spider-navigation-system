using SpiderNavigation.Models;

namespace SpiderNavigation.Utils
{
    public static class Visualizer
    {
        public static void DisplayPath(List<Position> path, int gridWidth, int gridHeight)
        {
            Console.WriteLine("\n🕸️  NAVIGATION PATH VISUALIZATION:\n");
            
            // Create grid
            var grid = new char[gridHeight + 1, gridWidth + 1];
            for (int y = 0; y <= gridHeight; y++)
                for (int x = 0; x <= gridWidth; x++)
                    grid[y, x] = '·';
            
            // Mark path
            for (int i = 0; i < path.Count; i++)
            {
                var step = path[i];
                var symbol = i == path.Count - 1 ? '★' : GetDirectionSymbol(step.Orientation);
                grid[step.Y, step.X] = symbol;
            }
            
            // Display grid (inverted Y-axis for proper visualization)
            for (int y = gridHeight; y >= 0; y--)
            {
                for (int x = 0; x <= gridWidth; x++)
                {
                    Console.Write(grid[y, x] + " ");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("\n📈 PATH STEPS:");
            for (int i = 0; i < path.Count; i++)
            {
                Console.WriteLine($"Step {i}: ({path[i].X}, {path[i].Y}) facing {path[i].Orientation}");
            }
        }
        
        private static char GetDirectionSymbol(string orientation) => orientation switch
        {
            "Up" => '↑',
            "Right" => '→', 
            "Down" => '↓',
            "Left" => '←',
            _ => '·'
        };
    }
}
