using MarsRover.Rovers;
using MarsRover.Rovers.Motors;
using Moq;
using NUnit.Framework;

namespace MarsRover.Tests.Unit.Rovers
{
    [TestFixture]
    public class RoverTests
    {
        private IRover rover;
        private Mock<IMotorFactory> mockMotorFactory;

        [SetUp]
        public void Setup()
        {
            mockMotorFactory = new Mock<IMotorFactory>();
            rover = new Rover(mockMotorFactory.Object);
        }

        [Test]
        public void RoverHasInitialLocation()
        {
            Assert.That(rover.CurrentLocation, Is.Not.Null);
            Assert.That(rover.CurrentLocation.Coordinate.X, Is.EqualTo(0));
            Assert.That(rover.CurrentLocation.Coordinate.Y, Is.EqualTo(0));
            Assert.That(rover.CurrentLocation.Orientation, Is.EqualTo((ORIENTATION)0));
            Assert.That(rover.CurrentLocation.Orientation, Is.EqualTo(ORIENTATION.NORTH));
        }

        [Test]
        public void RoverSetsLocation()
        {
            rover.CurrentLocation = new Location(9266, 90210, ORIENTATION.EAST);

            Assert.That(rover.CurrentLocation, Is.Not.Null);
            Assert.That(rover.CurrentLocation.Coordinate.X, Is.EqualTo(9266));
            Assert.That(rover.CurrentLocation.Coordinate.Y, Is.EqualTo(90210));
            Assert.That(rover.CurrentLocation.Orientation, Is.EqualTo(ORIENTATION.EAST));
        }

        [Test]
        public void RoverExecutesInstruction()
        {
            rover.CurrentLocation = new Location(9266, 90210, ORIENTATION.EAST);

            var movedLocation = new Location(42, 600, ORIENTATION.SOUTH);
            var mockMotor = new Mock<IMotor>();

            mockMotor.Setup(m => m.Move(rover.CurrentLocation)).Returns(movedLocation);
            mockMotorFactory.Setup(f => f.Construct('k')).Returns(mockMotor.Object);

            var newLocation = rover.ExecuteInstruction('k');
            Assert.That(newLocation, Is.EqualTo(movedLocation));
            Assert.That(rover.CurrentLocation, Is.Not.EqualTo(movedLocation));

            Assert.That(newLocation.Coordinate.X, Is.EqualTo(42));
            Assert.That(newLocation.Coordinate.Y, Is.EqualTo(600));
            Assert.That(newLocation.Orientation, Is.EqualTo(ORIENTATION.SOUTH));

            Assert.That(rover.CurrentLocation.Coordinate.X, Is.EqualTo(9266));
            Assert.That(rover.CurrentLocation.Coordinate.Y, Is.EqualTo(90210));
            Assert.That(rover.CurrentLocation.Orientation, Is.EqualTo(ORIENTATION.EAST));
        }
    }
}
