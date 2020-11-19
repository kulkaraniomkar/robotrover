using System.Drawing;
using System.Linq;

namespace MarsRover.Rovers
{
    public class Location
    {
        public Point Coordinate { get; set; }
        public ORIENTATION Orientation { get; set; }

        public string Description
        {
            get
            {
                return $"{Coordinate.X} {Coordinate.Y} {Orientation.ToString().First()}";
            }
        }

        public Location(int x, int y, ORIENTATION orientation)
        {
            Coordinate = new Point(x, y);
            Orientation = orientation;
        }
    }
}
