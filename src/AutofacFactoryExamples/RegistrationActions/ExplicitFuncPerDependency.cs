using System;
using System.Collections;
using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    public class ExplicitFuncPerDependency : IRegistrationAction
    {
        public IContainer Execute()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Shareholding>();

            builder.Register<Func<string, uint, Shareholding>>(context  =>
                {
                    var componentContext = context.Resolve<IComponentContext>();
                    Console.WriteLine("Creating Shareholding");
                    return (symbol, holding) => componentContext.Resolve<Shareholding>(new PositionalParameter(0, symbol), new PositionalParameter(1, holding));
                })
                .InstancePerDependency();

            return builder.Build();
        }
    }
}