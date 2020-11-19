using MarsRover.Rovers;
using MarsRover.Rovers.Motors;
using NUnit.Framework;

namespace MarsRover.Tests.Unit.Rovers.Motors
{
    [TestFixture]
    public class WestForwardMotorTests
    {
        private IForwardMotor motor;

        [SetUp]
        public void Setup()
        {
            motor = new WestForwardMotor();
        }

        [Test]
        public void MotorMovesWest()
        {
            var initialLocation = new Location(9266, 90210, ORIENTATION.WEST);

            var newLocation = motor.Move(initialLocation);
            Assert.That(newLocation.Coordinate.X, Is.EqualTo(9266 - 1));
            Assert.That(newLocation.Coordinate.Y, Is.EqualTo(90210));
            Assert.That(newLocation.Orientation, Is.EqualTo(ORIENTATION.WEST));
        }
    }
}
