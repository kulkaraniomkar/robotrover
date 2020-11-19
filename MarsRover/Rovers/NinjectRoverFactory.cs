using Ninject;

namespace MarsRover.Rovers
{
    public class NinjectRoverFactory : IRoverFactory
    {
        private readonly IKernel kernel;

        public NinjectRoverFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public IRover Construct()
        {
            return kernel.Get<IRover>();
        }
    }
}
