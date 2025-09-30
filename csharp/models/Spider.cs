using System;
using System.Collections.Generic;

namespace SpiderNavigation.Models
{
    public class Spider
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Orientation { get; set; }
        public int GridWidth { get; set; }
        public int GridHeight { get; set; }
        public List<Position> Path { get; set; }

        public Spider(int x, int y, string orientation, int gridWidth, int gridHeight)
        {
            X = x;
            Y = y;
            Orientation = orientation;
            GridWidth = gridWidth;
            GridHeight = gridHeight;
            Path = new List<Position> { new Position { X = x, Y = y, Orientation = orientation } };
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
            Path.Add(new Position { X = X, Y = Y, Orientation = Orientation });
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
            Path.Add(new Position { X = X, Y = Y, Orientation = Orientation });
        }

        public void MoveForward()
        {
            switch (Orientation)
            {
                case "Up":
                    if (Y < GridHeight) Y += 1;
                    break;
                case "Right":
                    if (X < GridWidth) X += 1;
                    break;
                case "Down":
                    if (Y > 0) Y -= 1;
                    break;
                case "Left":
                    if (X > 0) X -= 1;
                    break;
            }
            Path.Add(new Position { X = X, Y = Y, Orientation = Orientation });
        }

        public void ExecuteInstructions(string instructions)
        {
            foreach (var instruction in instructions)
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
                        Console.WriteLine($"Unknown instruction: {instruction}");
                        break;
                }
            }
        }

        public string GetFinalPosition()
        {
            return $"{X} {Y} {Orientation}";
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Orientation { get; set; } = "";
    }
}
