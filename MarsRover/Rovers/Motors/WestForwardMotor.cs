﻿namespace MarsRover.Rovers.Motors
{
    public class WestForwardMotor : IForwardMotor
    {
        public Location Move(Location currentLocation)
        {
            var newLocation = new Location(currentLocation.Coordinate.X - 1, currentLocation.Coordinate.Y, currentLocation.Orientation);

            return newLocation;
        }
    }
}
