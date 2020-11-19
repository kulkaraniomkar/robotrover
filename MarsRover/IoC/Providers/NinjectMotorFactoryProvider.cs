using MarsRover.Rovers.Motors;
using Ninject.Activation;

namespace MarsRover.IoC.Providers
{
    class NinjectMotorFactoryProvider : Provider<IMotorFactory>
    {
        protected override IMotorFactory CreateInstance(IContext context)
        {
            return new NinjectMotorFactory(context.Kernel);
        }
    }
}
