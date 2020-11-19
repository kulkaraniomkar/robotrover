using MarsRover.IoC.Providers;
using MarsRover.Rovers;
using MarsRover.Rovers.Motors;
using MarsRover.Satellites;
using Ninject.Modules;

namespace MarsRover.IoC.Modules
{
    internal class RoverModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISatellite>().To<Satellite>();
            Bind<IRover>().To<Rover>();
            Bind<IInstructionParser>().To<InstructionParser>();
            Bind<IRoverFactory>().ToProvider<NinjectRoverFactoryProvider>();
            Bind<IMotorFactory>().ToProvider<NinjectMotorFactoryProvider>();

            Bind<IMotor>().To<LeftMotor>().Named("L");
            Bind<IMotor>().To<RightMotor>().Named("R");
            Bind<IMotor>().To<ForwardMotor>().Named("F");

            Bind<IForwardMotor>().To<NorthForwardMotor>().Named(ORIENTATION.NORTH.ToString());
            Bind<IForwardMotor>().To<SouthForwardMotor>().Named(ORIENTATION.SOUTH.ToString());
            Bind<IForwardMotor>().To<EastForwardMotor>().Named(ORIENTATION.EAST.ToString());
            Bind<IForwardMotor>().To<WestForwardMotor>().Named(ORIENTATION.WEST.ToString());
        }
    }
}
