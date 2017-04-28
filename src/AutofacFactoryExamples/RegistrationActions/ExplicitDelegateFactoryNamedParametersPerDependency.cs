using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    public class ExplicitDelegateFactoryNamedParametersPerDependency : IRegistrationAction
    {
        public IContainer Execute()
        {
            var builder = new ContainerBuilder();
            builder.Register((context, parameters) =>
                {
                    return new Shareholding(parameters.Named<string>("symbol"), parameters.Named<uint>("holding"));
                })
                .InstancePerDependency();

            return builder.Build();
        }
    }
}