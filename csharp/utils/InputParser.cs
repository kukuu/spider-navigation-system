namespace SpiderNavigation.Utils
{
    public static class InputParser
    {
        public static (int Width, int Height) ParseWallSize(string input)
        {
            var parts = input.Trim().Split(' ');
            return (int.Parse(parts[0]), int.Parse(parts[1]));
        }

        public static (int X, int Y, string Orientation) ParseSpiderPosition(string input)
        {
            var parts = input.Trim().Split(' ');
            return (int.Parse(parts[0]), int.Parse(parts[1]), parts[2]);
        }

        public static string ParseInstructions(string input) => input.Trim();
    }
}