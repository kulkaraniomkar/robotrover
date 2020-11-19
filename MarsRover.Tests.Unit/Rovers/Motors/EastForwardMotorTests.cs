using MarsRover.Rovers;
using MarsRover.Rovers.Motors;
using NUnit.Framework;

namespace MarsRover.Tests.Unit.Rovers.Motors
{
    [TestFixture]
    public class EastForwardMotorTests
    {
        private IForwardMotor motor;

        [SetUp]
        public void Setup()
        {
            motor = new EastForwardMotor();
        }

        [Test]
        public void MotorMovesEast()
        {
            var initialLocation = new Location(9266, 90210, ORIENTATION.EAST);

            var newLocation = motor.Move(initialLocation);
            Assert.That(newLocation.Coordinate.X, Is.EqualTo(9266 + 1));
            Assert.That(newLocation.Coordinate.Y, Is.EqualTo(90210));
            Assert.That(newLocation.Orientation, Is.EqualTo(ORIENTATION.EAST));
        }
    }
}
