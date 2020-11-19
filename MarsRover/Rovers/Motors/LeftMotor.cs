using System;

namespace MarsRover.Rovers.Motors
{
    public class LeftMotor : IMotor
    {
        public Location Move(Location currentLocation)
        {
            var initialOrientation = Convert.ToInt16(currentLocation.Orientation);
            var enumCount = Enum.GetNames(typeof(ORIENTATION)).Length;
            var newOrientationNumeric = (initialOrientation - 1 + enumCount) % enumCount;
            var newOrientation = (ORIENTATION)newOrientationNumeric;

            return new Location(currentLocation.Coordinate.X, currentLocation.Coordinate.Y, newOrientation);
        }
    }
}
