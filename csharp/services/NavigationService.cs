using SpiderNavigation.Models;

namespace SpiderNavigation.Services
{
    public class NavigationService
    {
        public static Spider Navigate((int Width, int Height) wallSize, 
                                    (int X, int Y, string Orientation) spiderPosition, 
                                    string instructions)
        {
            var spider = new Spider(spiderPosition.X, spiderPosition.Y, spiderPosition.Orientation,
                                  wallSize.Width, wallSize.Height);
            
            spider.ExecuteInstructions(instructions);
            return spider;
        }
    }
}