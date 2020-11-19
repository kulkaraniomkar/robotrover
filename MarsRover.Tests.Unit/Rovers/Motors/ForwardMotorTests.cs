using MarsRover.Rovers;
using MarsRover.Rovers.Motors;
using Moq;
using NUnit.Framework;

namespace MarsRover.Tests.Unit.Rovers.Motors
{
    [TestFixture]
    public class ForwardForwardMotorTests
    {
        private IMotor motor;
        private Mock<IMotorFactory> mockMotorFactory;

        [SetUp]
        public void Setup()
        {
            mockMotorFactory = new Mock<IMotorFactory>();
            motor = new ForwardMotor(mockMotorFactory.Object);
        }

        [Test]
        public void MotorMovesForward()
        {
            var initialLocation = new Location(9266, 90210, ORIENTATION.EAST);
            var mockForwardMotor = new Mock<IForwardMotor>();
            var forwardLocation = new Location(42, 600, ORIENTATION.NORTH);

            mockForwardMotor.Setup(m => m.Move(initialLocation)).Returns(forwardLocation);
            mockMotorFactory.Setup(f => f.ConstructForwardFor(ORIENTATION.EAST)).Returns(mockForwardMotor.Object);

            var newLocation = motor.Move(initialLocation);
            Assert.That(newLocation, Is.EqualTo(forwardLocation));
        }
    }
}
