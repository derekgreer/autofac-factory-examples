using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    public class SharholdingRegistrationPerDependency : IRegistrationAction
    {
        public IContainer Execute()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Shareholding>().InstancePerDependency();
            return builder.Build();
        }
    }
}