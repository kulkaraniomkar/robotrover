﻿namespace MarsRover.Rovers.Motors
{
    public class NorthForwardMotor : IForwardMotor
    {
        public Location Move(Location currentLocation)
        {
            var newLocation = new Location(currentLocation.Coordinate.X, currentLocation.Coordinate.Y + 1, currentLocation.Orientation);

            return newLocation;
        }
    }
}
