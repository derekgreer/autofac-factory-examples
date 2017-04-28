using System;
using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    public class ExplicitFuncSingletonDelegate : IRegistrationAction
    {
        public IContainer Execute()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Shareholding>();

            builder.Register<Func<string, uint, Shareholding>>((context, parameters) =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                Console.WriteLine("Creating Shareholding");
                return (symbol, holding) => componentContext.Resolve<Shareholding>(new PositionalParameter(0, symbol), new PositionalParameter(1, holding));
            }).SingleInstance();

            return builder.Build();
        }
    }
}