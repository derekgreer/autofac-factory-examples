using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    public class ExplicitDelegateFactoryTypedParametersSingleton : IRegistrationAction
    {
        public IContainer Execute()
        {
            var builder = new ContainerBuilder();
            builder.Register((context, parameters) =>
                {
                    return new Shareholding(parameters.TypedAs<string>(), parameters.TypedAs<uint>());
                })
                .SingleInstance();

            return builder.Build();
        }
    }
}