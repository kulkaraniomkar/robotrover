using MarsRover.IoC.Modules;
using Ninject;

namespace MarsRover.IoC
{
    public class RoverModuleLoader
    {
        public void LoadModules(IKernel kernel)
        {
            kernel.Load<RoverModule>();
        }
    }
}
