using System;
using System.Collections.Generic;
using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    /// <summary>
    /// This 
    /// </summary>
    public class MemoizedFunc : IRegistrationAction
    {
        public IContainer Execute()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Shareholding>();

            builder.RegisterType<Dictionary<string, Shareholding>>().InstancePerLifetimeScope();

            builder.Register<Func<string, uint, Shareholding>>(context =>
                {
                    var componentContext = context.Resolve<IComponentContext>();
                    return (symbol, holding) =>
                    {
                        var dictionary = componentContext.Resolve<Dictionary<string, Shareholding>>();
                        if (dictionary.ContainsKey(symbol))
                        {
                            return dictionary[symbol];
                        }

                        var service = componentContext.Resolve<Shareholding>(new PositionalParameter(0, symbol), new PositionalParameter(1, holding));
                        dictionary[symbol] = service;
                        return service;
                    };
                });

            return builder.Build();
        }
    }
}