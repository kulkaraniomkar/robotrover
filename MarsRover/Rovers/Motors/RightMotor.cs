using System;

namespace MarsRover.Rovers.Motors
{
    public class RightMotor : IMotor
    {
        public Location Move(Location currentLocation)
        {
            var initialOrientation = Convert.ToInt16(currentLocation.Orientation);
            var newOrientationNumeric = (initialOrientation + 1) % Enum.GetNames(typeof(ORIENTATION)).Length;
            var newOrientation = (ORIENTATION)newOrientationNumeric;

            return new Location(currentLocation.Coordinate.X, currentLocation.Coordinate.Y, newOrientation);
        }
    }
}
