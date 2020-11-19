using MarsRover.Rovers;
using MarsRover.Rovers.Motors;
using Ninject;
using NUnit.Framework;

namespace MarsRover.Tests.Integration.Rovers.Motors
{
    [TestFixture]
    public class MotorFactoryTests : IntegrationTests
    {
        [Inject]
        public IMotorFactory MotorFactory { get; set; }

        [Test]
        public void ConstructLeftMotor()
        {
            var motor = MotorFactory.Construct('L');
            Assert.That(motor, Is.Not.Null);
            Assert.That(motor, Is.InstanceOf<LeftMotor>());
        }

        [Test]
        public void ConstructRightMotor()
        {
            var motor = MotorFactory.Construct('R');
            Assert.That(motor, Is.Not.Null);
            Assert.That(motor, Is.InstanceOf<RightMotor>());
        }

        [Test]
        public void ConstructForwardMotor()
        {
            var motor = MotorFactory.Construct('F');
            Assert.That(motor, Is.Not.Null);
            Assert.That(motor, Is.InstanceOf<ForwardMotor>());
        }

        [TestCase('B')]
        [TestCase('b')]
        [TestCase('l')]
        [TestCase('r')]
        [TestCase('f')]
        public void ThrowExceptionIfInvalidInstructionGiven(char badInstruction)
        {
            Assert.That(() => MotorFactory.Construct(badInstruction), Throws.ArgumentException.With.Message.EqualTo($"'{badInstruction}' is not a valid instruction"));
        }

        [Test]
        public void ConstructNorthForwardMotor()
        {
            var motor = MotorFactory.ConstructForwardFor(ORIENTATION.NORTH);
            Assert.That(motor, Is.Not.Null);
            Assert.That(motor, Is.InstanceOf<NorthForwardMotor>());
        }

        [Test]
        public void ConstructSouthForwardMotor()
        {
            var motor = MotorFactory.ConstructForwardFor(ORIENTATION.SOUTH);
            Assert.That(motor, Is.Not.Null);
            Assert.That(motor, Is.InstanceOf<SouthForwardMotor>());
        }

        [Test]
        public void ConstructEastForwardMotor()
        {
            var motor = MotorFactory.ConstructForwardFor(ORIENTATION.EAST);
            Assert.That(motor, Is.Not.Null);
            Assert.That(motor, Is.InstanceOf<EastForwardMotor>());
        }

        [Test]
        public void ConstructWestForwardMotor()
        {
            var motor = MotorFactory.ConstructForwardFor(ORIENTATION.WEST);
            Assert.That(motor, Is.Not.Null);
            Assert.That(motor, Is.InstanceOf<WestForwardMotor>());
        }
    }
}
