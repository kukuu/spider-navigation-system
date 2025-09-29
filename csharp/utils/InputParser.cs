namespace SpiderNavigation.Utils
{
    public static class InputParser
    {
        public static (int Width, int Height) ParseWallSize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Wall size input cannot be null or empty");

            var parts = input.Trim().Split(' ');
            if (parts.Length != 2)
                throw new ArgumentException("Wall size must contain exactly two numbers");

            if (!int.TryParse(parts[0], out int width) || !int.TryParse(parts[1], out int height))
                throw new ArgumentException("Wall size must contain valid integers");

            if (width < 0 || height < 0)
                throw new ArgumentException("Wall dimensions must be non-negative");

            return (width, height);
        }

        public static (int X, int Y, string Orientation) ParseSpiderPosition(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Spider position input cannot be null or empty");

            var parts = input.Trim().Split(' ');
            if (parts.Length != 3)
                throw new ArgumentException("Spider position must contain two numbers and an orientation");

            if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
                throw new ArgumentException("Spider coordinates must be valid integers");

            var validOrientations = new[] { "Up", "Right", "Down", "Left" };
            var orientation = parts[2];
            if (!validOrientations.Contains(orientation))
                throw new ArgumentException($"Invalid orientation. Must be one of: {string.Join(", ", validOrientations)}");

            return (x, y, orientation);
        }

        public static string ParseInstructions(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Instructions cannot be null or empty");

            var validInstructions = new[] { 'F', 'L', 'R' };
            if (input.Any(c => !validInstructions.Contains(c)))
                throw new ArgumentException($"Instructions can only contain: {string.Join(", ", validInstructions)}");

            return input.Trim();
        }
    }
}
