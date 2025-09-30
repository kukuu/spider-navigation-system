using SpiderNavigation.Models;

namespace SpiderNavigation.Services
{
    public class NavigationService
    {
        private readonly int _maxX;
        private readonly int _maxY;

        public NavigationService(int maxX, int maxY)
        {
            _maxX = maxX;
            _maxY = maxY;
        }

        public Spider Navigate(Spider spider, string instructions)
        {
            // Create a copy to avoid modifying the original
            var currentSpider = new Spider 
            { 
                X = spider.X, 
                Y = spider.Y, 
                Orientation = spider.Orientation 
            };

            foreach (var instruction in instructions)
            {
                ProcessInstruction(currentSpider, instruction);
            }

            return currentSpider;
        }

        private void ProcessInstruction(Spider spider, char instruction)
        {
            switch (instruction)
            {
                case 'L':
                    TurnLeft(spider);
                    break;
                case 'R':
                    TurnRight(spider);
                    break;
                case 'F':
                    MoveForward(spider);
                    break;
                // Ignore any other characters (like 'E')
                default:
                    break;
            }
        }

        private void TurnLeft(Spider spider)
        {
            spider.Orientation = spider.Orientation switch
            {
                "Up" => "Left",
                "Left" => "Down", 
                "Down" => "Right",
                "Right" => "Up",
                _ => spider.Orientation
            };
        }

        private void TurnRight(Spider spider)
        {
            spider.Orientation = spider.Orientation switch
            {
                "Up" => "Right",
                "Right" => "Down",
                "Down" => "Left",
                "Left" => "Up",
                _ => spider.Orientation
            };
        }

        private void MoveForward(Spider spider)
        {
            switch (spider.Orientation)
            {
                case "Up":
                    if (spider.Y < _maxY) spider.Y++;
                    break;
                case "Right":
                    if (spider.X < _maxX) spider.X++;
                    break;
                case "Down":
                    if (spider.Y > 0) spider.Y--;
                    break;
                case "Left":
                    if (spider.X > 0) spider.X--;
                    break;
            }
        }
    }
}
