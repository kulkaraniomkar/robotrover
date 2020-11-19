using MarsRover.Rovers;
using Ninject.Activation;

namespace MarsRover.IoC.Providers
{
    class NinjectRoverFactoryProvider : Provider<IRoverFactory>
    {
        protected override IRoverFactory CreateInstance(IContext context)
        {
            return new NinjectRoverFactory(context.Kernel);
        }
    }
}
