using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    public class ExplicitDelegateFactoryTypedParametersPerDependency : IRegistrationAction
    {
        public IContainer Execute()
        {
            var builder = new ContainerBuilder();
            builder.Register((context, parameters) =>
                {
                    return new Shareholding(parameters.TypedAs<string>(), parameters.TypedAs<uint>());
                })
                .InstancePerDependency();

            return builder.Build();
        }
    }
}