using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    public class IndexPerDependency : IRegistrationAction
    {
        public IContainer Execute()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Shareholding>().Keyed<Shareholding>(ExampleEnum.TheOnlyState).InstancePerDependency();
            return builder.Build();
        }
    }
}