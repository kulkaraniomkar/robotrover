using MarsRover.Rovers.Motors;

namespace MarsRover.Rovers
{
    public class Rover : IRover
    {
        //INFO: Ideally, this would not be a stateful object.
        //The current state of the rover and the execution of instructions should live in separate objects.
        //However, for expediency and simplicity, we will combine those two here
        public Location CurrentLocation { get; set; }

        private readonly IMotorFactory motorFactory;

        public Rover(IMotorFactory motorFactory)
        {
            this.motorFactory = motorFactory;

            CurrentLocation = new Location(0, 0, 0);
        }

        public Location ExecuteInstruction(char instruction)
        {
            var motor = motorFactory.Construct(instruction);
            var newLocation = motor.Move(CurrentLocation);

            return newLocation;
        }
    }
}
