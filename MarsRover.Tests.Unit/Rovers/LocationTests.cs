using MarsRover.Rovers;
using NUnit.Framework;
using System.Linq;

namespace MarsRover.Tests.Unit.Rovers
{
    [TestFixture]
    public class LocationTests
    {
        [TestCase(ORIENTATION.EAST)]
        [TestCase(ORIENTATION.NORTH)]
        [TestCase(ORIENTATION.SOUTH)]
        [TestCase(ORIENTATION.WEST)]
        public void LocationIsInitialized(ORIENTATION orientation)
        {
            var location = new Location(9266, 90210, orientation);
            Assert.That(location.Coordinate.X, Is.EqualTo(9266));
            Assert.That(location.Coordinate.Y, Is.EqualTo(90210));
            Assert.That(location.Orientation, Is.EqualTo(orientation));
        }

        [TestCase(ORIENTATION.EAST)]
        [TestCase(ORIENTATION.NORTH)]
        [TestCase(ORIENTATION.SOUTH)]
        [TestCase(ORIENTATION.WEST)]
        public void LocationHasDescription(ORIENTATION orientation)
        {
            var location = new Location(9266, 90210, orientation);
            Assert.That(location.Description, Is.EqualTo($"9266 90210 {orientation.ToString().First()}"));
        }
    }
}
