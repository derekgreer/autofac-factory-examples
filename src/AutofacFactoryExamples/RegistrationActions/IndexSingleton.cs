using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    public class IndexSingleton : IRegistrationAction
    {
        public IContainer Execute()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Shareholding>().Keyed<Shareholding>(ExampleEnum.TheOnlyState).SingleInstance();
            return builder.Build();
        }
    }
}