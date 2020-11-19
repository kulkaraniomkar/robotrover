namespace MarsRover.Rovers
{
    public interface IRover
    {
        Location CurrentLocation { get; set; }

        Location ExecuteInstruction(char instruction);
    }
}
