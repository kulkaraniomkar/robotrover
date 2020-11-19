using MarsRover.Rovers;
using MarsRover.Rovers.Motors;
using MarsRover.Satellites;
using NUnit.Framework;

namespace MarsRover.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class RoverModuleTests : IntegrationTests
    {
        [Test]
        public void SatelliteIsConstructed()
        {
            GetAndAssertInstance<ISatellite, Satellite>();
        }

        private void GetAndAssertInstance<I, T>()
            where T : I
        {
            var instance = GetNewInstanceOf<I>();
            AssertInstance<I, T>(instance);
        }

        private void AssertInstance<I, T>(I instance)
            where T : I
        {
            Assert.That(instance, Is.Not.Null);
            Assert.That(instance, Is.InstanceOf<T>());
        }

        private void GetAndAssertInstance<I, T>(string name)
            where T : I
        {
            var instance = GetNewInstanceOf<I>(name);
            AssertInstance<I, T>(instance);
        }

        [Test]
        public void RoverIsConstructed()
        {
            GetAndAssertInstance<IRover, Rover>();
        }

        [Test]
        public void InstructionParserIsConstructed()
        {
            GetAndAssertInstance<IInstructionParser, InstructionParser>();
        }

        [Test]
        public void RoverFactoryIsConstructed()
        {
            GetAndAssertInstance<IRoverFactory, NinjectRoverFactory>();
        }

        [Test]
        public void MotorFactoryIsConstructed()
        {
            GetAndAssertInstance<IMotorFactory, NinjectMotorFactory>();
        }

        [Test]
        public void LeftMotorIsConstructed()
        {
            GetAndAssertInstance<IMotor, LeftMotor>("L");
        }

        [Test]
        public void RightMotorIsConstructed()
        {
            GetAndAssertInstance<IMotor, RightMotor>("R");
        }

        [Test]
        public void ForwardMotorIsConstructed()
        {
            GetAndAssertInstance<IMotor, ForwardMotor>("F");
        }

        [Test]
        public void NorthForwardMotorIsConstructed()
        {
            GetAndAssertInstance<IForwardMotor, NorthForwardMotor>(ORIENTATION.NORTH.ToString());
        }

        [Test]
        public void SouthForwardMotorIsConstructed()
        {
            GetAndAssertInstance<IForwardMotor, SouthForwardMotor>(ORIENTATION.SOUTH.ToString());
        }

        [Test]
        public void EastForwardMotorIsConstructed()
        {
            GetAndAssertInstance<IForwardMotor, EastForwardMotor>(ORIENTATION.EAST.ToString());
        }

        [Test]
        public void WestForwardMotorIsConstructed()
        {
            GetAndAssertInstance<IForwardMotor, WestForwardMotor>(ORIENTATION.WEST.ToString());
        }
    }
}
