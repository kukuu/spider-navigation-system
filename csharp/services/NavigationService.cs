using SpiderNavigation.Models;

namespace SpiderNavigation.Services
{
    public static class NavigationService
    {
        public static Spider Navigate((int Width, int Height) wallSize, 
                                    (int X, int Y, string Orientation) spiderPosition, 
                                    string instructions)
        {
            // Validate spider starts within grid bounds
            if (spiderPosition.X < 0 || spiderPosition.X > wallSize.Width || 
                spiderPosition.Y < 0 || spiderPosition.Y > wallSize.Height)
            {
                throw new ArgumentException("Spider starting position is outside wall boundaries");
            }

            var spider = new Spider(spiderPosition.X, spiderPosition.Y, spiderPosition.Orientation,
                                  wallSize.Width, wallSize.Height);
            
            spider.ExecuteInstructions(instructions);
            return spider;
        }
    }
}
