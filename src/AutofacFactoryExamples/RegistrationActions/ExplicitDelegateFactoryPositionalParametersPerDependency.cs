using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    public class ExplicitDelegateFactoryPositionalParametersPerDependency : IRegistrationAction
    {
        public IContainer Execute()
        {
            var builder = new ContainerBuilder();
            builder.Register((context, parameters) =>
                {
                    return new Shareholding(parameters.Positional<string>(0), parameters.Positional<uint>(1));
                })
                .InstancePerDependency();

            return builder.Build();
        }
    }
}