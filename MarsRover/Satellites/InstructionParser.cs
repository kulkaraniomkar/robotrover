using MarsRover.Rovers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MarsRover.Satellites
{
    public class InstructionParser : IInstructionParser
    {
        public Point ParseWorldMapSize(string input)
        {
            var sections = input.Split('\n').Where(s => !string.IsNullOrWhiteSpace(s));
            var worldSection = sections.First().Trim();
            var coordinates = worldSection.Split(' ').Select(s => Convert.ToInt32(s));

            var mapSize = new Point();
            mapSize.X = coordinates.First();
            mapSize.Y = coordinates.Last();

            return mapSize;
        }

        public Dictionary<Location, IEnumerable<char>> ParseRovers(string input)
        {
            var sections = input.Split('\n').Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            var rovers = new Dictionary<Location, IEnumerable<char>>();

            for (var i = 1; i < sections.Length; i += 2)
            {
                var location = ParseLocation(sections[i].Trim());
                var commands = ParseCommands(sections[i + 1].Trim());

                rovers[location] = commands;
            }

            return rovers;
        }

        private IEnumerable<char> ParseCommands(string input)
        {
            return input;
        }

        private Location ParseLocation(string input)
        {
            var sections = input.Split(' ');
            var x = Convert.ToInt32(sections[0]);
            var y = Convert.ToInt32(sections[1]);
            var orientation = GetOrientation(sections[2]);

            var location = new Location(x, y, orientation);

            return location;
        }

        private ORIENTATION GetOrientation(string input)
        {
            switch (input)
            {
                case "N": return ORIENTATION.NORTH;
                case "S": return ORIENTATION.SOUTH;
                case "E": return ORIENTATION.EAST;
                case "W": return ORIENTATION.WEST;
                default: throw new ArgumentException($"'{input}' is not a valid orientation");
            }
        }
    }
}
