namespace MarsRover.Rovers.Motors
{
    public class ForwardMotor : IMotor
    {
        private readonly IMotorFactory motorFactory;

        public ForwardMotor(IMotorFactory motorFactory)
        {
            this.motorFactory = motorFactory;
        }

        public Location Move(Location currentLocation)
        {
            var forwardMotor = motorFactory.ConstructForwardFor(currentLocation.Orientation);
            var newLocation = forwardMotor.Move(currentLocation);

            return newLocation;
        }
    }
}
