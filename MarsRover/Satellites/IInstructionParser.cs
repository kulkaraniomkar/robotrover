using MarsRover.Rovers;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Satellites
{
    public interface IInstructionParser
    {
        Point ParseWorldMapSize(string input);
        Dictionary<Location, IEnumerable<char>> ParseRovers(string input);
    }
}
