using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    public class SharholdingRegistrationSingleton : IRegistrationAction
    {
        public IContainer Execute()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Shareholding>().SingleInstance();
            return builder.Build();
        }
    }
}