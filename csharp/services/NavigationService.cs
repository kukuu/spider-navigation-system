using SpiderNavigation.Models;

namespace SpiderNavigation.Services
{
    public class NavigationService
    {
        public Spider Navigate(Spider spider, string instructions)
        {
            var currentSpider = new Spider(spider.X, spider.Y, spider.Orientation, spider.MaxX, spider.MaxY);
            
            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case 'L': currentSpider.TurnLeft(); break;
                    case 'R': currentSpider.TurnRight(); break;
                    case 'F': currentSpider.MoveForward(); break;
                }
            }
            
            return currentSpider;
        }
    }
}
