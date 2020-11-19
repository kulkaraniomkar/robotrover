using MarsRover.Rovers;
using NUnit.Framework;
using System;

namespace MarsRover.Tests.Unit.Rovers
{
    [TestFixture]
    public class OrientationTests
    {
        [TestCase(ORIENTATION.NORTH, 0)]
        [TestCase(ORIENTATION.EAST, 1)]
        [TestCase(ORIENTATION.SOUTH, 2)]
        [TestCase(ORIENTATION.WEST, 3)]
        public void OrientationIsCorrectValue(ORIENTATION orientation, short value)
        {
            Assert.That(Convert.ToInt16(orientation), Is.EqualTo(value));
        }
    }
}
