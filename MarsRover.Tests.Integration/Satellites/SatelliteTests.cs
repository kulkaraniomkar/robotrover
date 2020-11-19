using MarsRover.Satellites;
using Ninject;
using NUnit.Framework;

namespace MarsRover.Tests.Integration.Satellites
{
    [TestFixture]
    public class SatelliteTests : IntegrationTests
    {
        [Inject]
        public ISatellite Satellite { get; set; }

        [Test]
        public void SatelliteRetrievesCorrectResults()
        {
            var input = @"5 3

                1 1 E

                RFRFRFRF

                3 2 N

                FRRFLLFFRRFLL

                0 3 W

                LLFFFLFLFL";

            var results = Satellite.ExecuteCommands(input);

            Assert.That(results, Is.EqualTo("1 1 E\n\n3 3 N LOST\n\n2 3 S"));
        }
    }
}
