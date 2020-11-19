namespace MarsRover.Rovers.Motors
{
    public interface IMotorFactory
    {
        IMotor Construct(char instruction);
        IForwardMotor ConstructForwardFor(ORIENTATION orientation);
    }
}
