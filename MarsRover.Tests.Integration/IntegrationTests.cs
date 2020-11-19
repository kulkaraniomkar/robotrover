using MarsRover.IoC;
using Ninject;
using NUnit.Framework;

namespace MarsRover.Tests.Integration
{
    [TestFixture]
    public abstract class IntegrationTests
    {
        private IKernel kernel;

        [OneTimeSetUp]
        public void IntegrationOneTimeSetUp()
        {
            kernel = new StandardKernel();

            var moduleLoader = new RoverModuleLoader();
            moduleLoader.LoadModules(kernel);
        }

        [SetUp]
        public void IntegrationSetup()
        {
            kernel.Inject(this);
        }

        protected T GetNewInstanceOf<T>()
        {
            return kernel.Get<T>();
        }

        protected T GetNewInstanceOf<T>(string name)
        {
            return kernel.Get<T>(name);
        }
    }
}
