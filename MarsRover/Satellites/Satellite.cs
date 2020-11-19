using MarsRover.Rovers;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Satellites
{
    public class Satellite : ISatellite
    {
        private readonly IInstructionParser instructionParser;
        private readonly IRoverFactory roverFactory;

        public Satellite(IInstructionParser instructionParser, IRoverFactory roverFactory)
        {
            this.instructionParser = instructionParser;
            this.roverFactory = roverFactory;
        }

        public string ExecuteCommands(string commands)
        {
            var maximumMapCoordinate = instructionParser.ParseWorldMapSize(commands);
            var roversAndInstructions = instructionParser.ParseRovers(commands);
            var results = new List<string>();
            var lostCommands = new Dictionary<string, string>();

            foreach (var kvp in roversAndInstructions)
            {
                var initialLocation = kvp.Key;
                var instructions = kvp.Value;

                var rover = roverFactory.Construct();
                rover.CurrentLocation = initialLocation;

                var result = ExecuteInstructions(rover, instructions, maximumMapCoordinate, lostCommands);
                results.Add(result);
            }

            return string.Join("\n\n", results);
        }

        private string ExecuteInstructions(IRover rover, IEnumerable<char> instructions, Point maximumMapCoordinate, Dictionary<string, string> lostCommands)
        {
            foreach (var instruction in instructions)
            {
                var newLocation = rover.ExecuteInstruction(instruction);

                if (lostCommands.ContainsKey(rover.CurrentLocation.Description) && lostCommands[rover.CurrentLocation.Description] == newLocation.Description)
                    continue;

                if (IsLost(newLocation, maximumMapCoordinate))
                {
                    lostCommands[rover.CurrentLocation.Description] = newLocation.Description;
                    return GetResult(rover.CurrentLocation, true);
                }

                rover.CurrentLocation = newLocation;
            }

            return GetResult(rover.CurrentLocation, false);
        }

        private bool IsLost(Location location, Point maximumMapCoordinate)
        {
            return location.Coordinate.X < 0
                || location.Coordinate.Y < 0
                || location.Coordinate.X > maximumMapCoordinate.X
                || location.Coordinate.Y > maximumMapCoordinate.Y;
        }

        private string GetResult(Location roverLocation, bool isLost)
        {
            var lostResult = isLost ? " LOST" : string.Empty;
            return $"{roverLocation.Description}{lostResult}";
        }
    }
}
