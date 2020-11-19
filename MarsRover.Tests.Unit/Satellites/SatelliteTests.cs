using MarsRover.Rovers;
using MarsRover.Satellites;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Tests.Unit.Satellites
{
    [TestFixture]
    public class SatelliteTests
    {
        private ISatellite satellite;
        private Mock<IInstructionParser> mockInstructionParser;
        private Mock<IRoverFactory> mockRoverFactory;

        [SetUp]
        public void Setup()
        {
            mockInstructionParser = new Mock<IInstructionParser>();
            mockRoverFactory = new Mock<IRoverFactory>();
            satellite = new Satellite(mockInstructionParser.Object, mockRoverFactory.Object);
        }

        [Test]
        public void SatelliteExecutesCommand()
        {
            var input = "this is my input";

            var worldSize = new Point(9266, 90210);
            mockInstructionParser.Setup(p => p.ParseWorldMapSize(input)).Returns(worldSize);

            var roversAndInstructions = new Dictionary<Location, IEnumerable<char>>();
            roversAndInstructions[new Location(42, 600, ORIENTATION.EAST)] = "commands";

            mockInstructionParser.Setup(p => p.ParseRovers(input)).Returns(roversAndInstructions);

            var mockRover = new Mock<IRover>();
            mockRoverFactory.Setup(f => f.Construct()).Returns(mockRover.Object);

            mockRover.SetupAllProperties();
            mockRover.Setup(r => r.ExecuteInstruction(It.IsAny<char>())).Returns((char i) => GetNewLocation(mockRover.Object.CurrentLocation));

            var results = satellite.ExecuteCommands(input);
            Assert.That(results, Is.EqualTo(@"50 608 E"));
        }

        private Location GetNewLocation(Location currentLocation)
        {
            var newOrientationNumeric = ((short)currentLocation.Orientation + 1) % Enum.GetNames(typeof(ORIENTATION)).Length;
            return new Location(currentLocation.Coordinate.X + 1, currentLocation.Coordinate.Y + 1, (ORIENTATION)newOrientationNumeric);
        }

        [Test]
        public void SatelliteExecutesMultipleCommands()
        {
            var input = "this is my input";

            var worldSize = new Point(9266, 90210);
            mockInstructionParser.Setup(p => p.ParseWorldMapSize(input)).Returns(worldSize);

            var roversAndInstructions = new Dictionary<Location, IEnumerable<char>>();
            roversAndInstructions[new Location(42, 600, ORIENTATION.EAST)] = "commands";
            roversAndInstructions[new Location(1337, 1234, ORIENTATION.SOUTH)] = "other commands";

            mockInstructionParser.Setup(p => p.ParseRovers(input)).Returns(roversAndInstructions);

            var mockRover = new Mock<IRover>();
            mockRoverFactory.Setup(f => f.Construct()).Returns(mockRover.Object);

            mockRover.SetupAllProperties();
            mockRover.Setup(r => r.ExecuteInstruction(It.IsAny<char>())).Returns((char i) => GetNewLocation(mockRover.Object.CurrentLocation));

            var results = satellite.ExecuteCommands(input);
            Assert.That(results, Is.EqualTo("50 608 E\n\n1351 1248 N"));
        }

        [Test]
        public void SatelliteExecutesCommandThatResultsInLostRover()
        {
            var input = "this is my input";

            var worldSize = new Point(9266, 90210);
            mockInstructionParser.Setup(p => p.ParseWorldMapSize(input)).Returns(worldSize);

            var roversAndInstructions = new Dictionary<Location, IEnumerable<char>>();
            roversAndInstructions[new Location(9260, 600, ORIENTATION.EAST)] = "commands";

            mockInstructionParser.Setup(p => p.ParseRovers(input)).Returns(roversAndInstructions);

            var mockRover = new Mock<IRover>();
            mockRoverFactory.Setup(f => f.Construct()).Returns(mockRover.Object);

            mockRover.SetupAllProperties();
            mockRover.Setup(r => r.ExecuteInstruction(It.IsAny<char>())).Returns((char i) => GetNewLocation(mockRover.Object.CurrentLocation));

            var results = satellite.ExecuteCommands(input);
            Assert.That(results, Is.EqualTo("9266 606 W LOST"));
        }

        [Test]
        public void SatelliteExecutesCommandsAndOneResultsInLostRover()
        {
            var input = "this is my input";

            var worldSize = new Point(9266, 90210);
            mockInstructionParser.Setup(p => p.ParseWorldMapSize(input)).Returns(worldSize);

            var roversAndInstructions = new Dictionary<Location, IEnumerable<char>>();
            roversAndInstructions[new Location(9260, 600, ORIENTATION.EAST)] = "commands";
            roversAndInstructions[new Location(1337, 1234, ORIENTATION.SOUTH)] = "other commands";

            mockInstructionParser.Setup(p => p.ParseRovers(input)).Returns(roversAndInstructions);

            var mockRover = new Mock<IRover>();
            mockRoverFactory.Setup(f => f.Construct()).Returns(mockRover.Object);

            mockRover.SetupAllProperties();
            mockRover.Setup(r => r.ExecuteInstruction(It.IsAny<char>())).Returns((char i) => GetNewLocation(mockRover.Object.CurrentLocation));

            var results = satellite.ExecuteCommands(input);
            Assert.That(results, Is.EqualTo("9266 606 W LOST\n\n1351 1248 N"));
        }

        [Test]
        public void SatelliteExecutesCommandsAndIgnoresCommandsThatResultedInALostRoverBefore()
        {
            var input = "this is my input";

            var worldSize = new Point(9266, 90210);
            mockInstructionParser.Setup(p => p.ParseWorldMapSize(input)).Returns(worldSize);

            var roversAndInstructions = new Dictionary<Location, IEnumerable<char>>();
            roversAndInstructions[new Location(9260, 600, ORIENTATION.EAST)] = "commands";
            roversAndInstructions[new Location(9260, 600, ORIENTATION.EAST)] = "other commands";

            mockInstructionParser.Setup(p => p.ParseRovers(input)).Returns(roversAndInstructions);

            var mockRover = new Mock<IRover>();
            mockRoverFactory.Setup(f => f.Construct()).Returns(mockRover.Object);

            mockRover.SetupAllProperties();
            mockRover.Setup(r => r.ExecuteInstruction(It.IsAny<char>())).Returns((char i) => GetNewLocation(mockRover.Object.CurrentLocation));

            var results = satellite.ExecuteCommands(input);
            Assert.That(results, Is.EqualTo("9266 606 W LOST\n\n9266 606 W"));
        }
    }
}
