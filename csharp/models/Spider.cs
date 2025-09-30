namespace SpiderNavigation.Models
{
    public class Spider
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Orientation { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public Spider(int x, int y, string orientation, int maxX, int maxY)
        {
            X = x;
            Y = y;
            Orientation = orientation;
            MaxX = maxX;
            MaxY = maxY;
        }

        public void TurnLeft()
        {
            Orientation = Orientation switch
            {
                "Up" => "Left",
                "Left" => "Down", 
                "Down" => "Right",
                "Right" => "Up",
                _ => Orientation
            };
        }

        public void TurnRight()
        {
            Orientation = Orientation switch
            {
                "Up" => "Right",
                "Right" => "Down",
                "Down" => "Left", 
                "Left" => "Up",
                _ => Orientation
            };
        }

        public void MoveForward()
        {
            switch (Orientation)
            {
                case "Up": if (Y < MaxY) Y++; break;
                case "Right": if (X < MaxX) X++; break;
                case "Down": if (Y > 0) Y--; break;
                case "Left": if (X > 0) X--; break;
            }
        }

        public string GetFinalPosition() => $"{X} {Y} {Orientation}";
    }
}
