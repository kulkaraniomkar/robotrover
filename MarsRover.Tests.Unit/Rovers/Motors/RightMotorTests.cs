using MarsRover.Rovers;
using MarsRover.Rovers.Motors;
using NUnit.Framework;

namespace MarsRover.Tests.Unit.Rovers.Motors
{
    [TestFixture]
    public class RightMotorTests
    {
        private IMotor motor;

        [SetUp]
        public void Setup()
        {
            motor = new RightMotor();
        }

        [TestCase(ORIENTATION.EAST, ORIENTATION.SOUTH)]
        [TestCase(ORIENTATION.SOUTH, ORIENTATION.WEST)]
        [TestCase(ORIENTATION.WEST, ORIENTATION.NORTH)]
        [TestCase(ORIENTATION.NORTH, ORIENTATION.EAST)]
        public void RightTurnsOrientation(ORIENTATION start, ORIENTATION finish)
        {
            var initialLocation = new Location(9266, 90210, start);

            var newLocation = motor.Move(initialLocation);
            Assert.That(newLocation.Coordinate.X, Is.EqualTo(9266));
            Assert.That(newLocation.Coordinate.Y, Is.EqualTo(90210));
            Assert.That(newLocation.Orientation, Is.EqualTo(finish));
        }
    }
}
