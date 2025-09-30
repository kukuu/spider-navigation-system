namespace SpiderNavigation.Models
{
    public class Spider
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Orientation { get; set; }

        public override string ToString()
        {
            return $"{X} {Y} {Orientation}";
        }
    }
}
