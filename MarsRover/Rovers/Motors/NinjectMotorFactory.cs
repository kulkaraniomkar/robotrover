using Ninject;
using System;

namespace MarsRover.Rovers.Motors
{
    public class NinjectMotorFactory : IMotorFactory
    {
        private readonly IKernel kernel;

        public NinjectMotorFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public IMotor Construct(char instruction)
        {
            try
            {
                return kernel.Get<IMotor>(instruction.ToString());
            }
            catch
            {
                throw new ArgumentException($"'{instruction}' is not a valid instruction");
            }
        }

        public IForwardMotor ConstructForwardFor(ORIENTATION orientation)
        {
            return kernel.Get<IForwardMotor>(orientation.ToString());
        }
    }
}
