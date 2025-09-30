using System;

namespace SpiderNavigation.Utils
{
    public static class InputParser
    {
        public static (int maxX, int maxY) ParseWallSize(string input)
        {
            var parts = input.Trim().Split(' ');
            if (parts.Length != 2)
                throw new ArgumentException("Invalid dimensions format. Expected: 'width height'");
            
            if (!int.TryParse(parts[0], out int maxX) || !int.TryParse(parts[1], out int maxY))
                throw new ArgumentException("Invalid dimensions values. Expected numbers.");
            
            return (maxX, maxY);
        }

        public static (int x, int y, string orientation) ParseSpiderPosition(string input)
        {
            var parts = input.Trim().Split(' ');
            if (parts.Length != 3)
                throw new ArgumentException("Invalid position format. Expected: 'x y orientation'");
            
            if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
                throw new ArgumentException("Invalid position values. Expected numbers for x and y.");
            
            var orientation = parts[2];
            var validOrientations = new[] { "Up", "Down", "Left", "Right" };
            if (Array.IndexOf(validOrientations, orientation) == -1)
                throw new ArgumentException("Invalid orientation. Expected: Up, Down, Left, or Right");
            
            return (x, y, orientation);
        }

        public static string ParseInstructions(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Instructions cannot be empty");
            
            return input.Trim();
        }
    }
}
