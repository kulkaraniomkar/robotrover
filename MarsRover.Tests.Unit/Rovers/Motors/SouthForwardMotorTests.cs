using MarsRover.Rovers;
using MarsRover.Rovers.Motors;
using NUnit.Framework;

namespace MarsRover.Tests.Unit.Rovers.Motors
{
    [TestFixture]
    public class SouthForwardMotorTests
    {
        private IForwardMotor motor;

        [SetUp]
        public void Setup()
        {
            motor = new SouthForwardMotor();
        }

        [Test]
        public void MotorMovesSouth()
        {
            var initialLocation = new Location(9266, 90210, ORIENTATION.SOUTH);

            var newLocation = motor.Move(initialLocation);
            Assert.That(newLocation.Coordinate.X, Is.EqualTo(9266));
            Assert.That(newLocation.Coordinate.Y, Is.EqualTo(90210 - 1));
            Assert.That(newLocation.Orientation, Is.EqualTo(ORIENTATION.SOUTH));
        }
    }
}
