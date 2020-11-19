using MarsRover.Rovers;
using Ninject;
using NUnit.Framework;

namespace MarsRover.Tests.Integration.Rovers
{
    [TestFixture]
    public class RoverFactoryTests : IntegrationTests
    {
        [Inject]
        public IRoverFactory RoverFactory { get; set; }

        [Test]
        public void RoverIsConstructed()
        {
            var rover = RoverFactory.Construct();
            Assert.That(rover, Is.Not.Null);
            Assert.That(rover, Is.InstanceOf<Rover>());
        }
    }
}
