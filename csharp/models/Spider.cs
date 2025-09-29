namespace SpiderNavigation.Models
{
    public class Spider
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public string Orientation { get; private set; }
        public int GridWidth { get; private set; }
        public int GridHeight { get; private set; }
        public List<Position> Path { get; private set; }

        public Spider(int x, int y, string orientation, int gridWidth, int gridHeight)
        {
            X = x;
            Y = y;
            Orientation = orientation;
            GridWidth = gridWidth;
            GridHeight = gridHeight;
            Path = new List<Position> { new Position(x, y, orientation) };
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
            Path.Add(new Position(X, Y, Orientation));
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
            Path.Add(new Position(X, Y, Orientation));
        }

        public void MoveForward()
        {
            switch (Orientation)
            {
                case "Up" when Y < GridHeight:
                    Y++;
                    break;
                case "Right" when X < GridWidth:
                    X++;
                    break;
                case "Down" when Y > 0:
                    Y--;
                    break;
                case "Left" when X > 0:
                    X--;
                    break;
            }
            Path.Add(new Position(X, Y, Orientation));
        }

        public void ExecuteInstructions(string instructions)
        {
            foreach (char instruction in instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'F':
                        MoveForward();
                        break;
                    default:
                        Console.WriteLine($"Warning: Unknown instruction '{instruction}'");
                        break;
                }
            }
        }

        public string GetFinalPosition() => $"{X} {Y} {Orientation}";
    }

    public record Position(int X, int Y, string Orientation);
}