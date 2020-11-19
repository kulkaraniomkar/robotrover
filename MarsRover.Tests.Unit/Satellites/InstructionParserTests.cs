using MarsRover.Rovers;
using MarsRover.Satellites;
using NUnit.Framework;
using System.Linq;

namespace MarsRover.Tests.Unit.Satellites
{
    [TestFixture]
    public class InstructionParserTests
    {
        private const string input = @"
            5 3

            1 1 E

            RFRFRFRF

            3 2 N

            FRRFLLFFRRFLL

            0 3 W

            LLFFFLFLFL";

        private IInstructionParser instructionParser;

        [SetUp]
        public void Setup()
        {
            instructionParser = new InstructionParser();
        }

        [Test]
        public void ParseWorldMapSize()
        {
            var mapSize = instructionParser.ParseWorldMapSize(input);
            Assert.That(mapSize.X, Is.EqualTo(5));
            Assert.That(mapSize.Y, Is.EqualTo(3));
        }

        [Test]
        public void ParseRovers()
        {
            var rovers = instructionParser.ParseRovers(input);
            Assert.That(rovers.Count, Is.EqualTo(3));

            var locations = rovers.Keys.ToArray();

            Assert.That(locations[0].Coordinate.X, Is.EqualTo(1));
            Assert.That(locations[0].Coordinate.Y, Is.EqualTo(1));
            Assert.That(locations[0].Orientation, Is.EqualTo(ORIENTATION.EAST));
            Assert.That(locations[1].Coordinate.X, Is.EqualTo(3));
            Assert.That(locations[1].Coordinate.Y, Is.EqualTo(2));
            Assert.That(locations[1].Orientation, Is.EqualTo(ORIENTATION.NORTH));
            Assert.That(locations[2].Coordinate.X, Is.EqualTo(0));
            Assert.That(locations[2].Coordinate.Y, Is.EqualTo(3));
            Assert.That(locations[2].Orientation, Is.EqualTo(ORIENTATION.WEST));

            Assert.That(rovers[locations[0]], Is.EqualTo(new[]
            {
                'R', 'F', 'R', 'F', 'R', 'F', 'R', 'F'
            }));
            Assert.That(rovers[locations[1]], Is.EqualTo(new[]
            {
                'F', 'R', 'R', 'F', 'L', 'L', 'F', 'F', 'R', 'R', 'F', 'L', 'L'
            }));
            Assert.That(rovers[locations[2]], Is.EqualTo(new[]
            {
                'L', 'L', 'F', 'F', 'F', 'L', 'F', 'L', 'F', 'L'
            }));
        }
    }
}
