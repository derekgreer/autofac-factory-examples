using System;
using Autofac;
using Autofac.Features.Indexed;
using AutofacFactoryExamples.RegistrationActions;

namespace AutofacFactoryExamples.ResolveActions
{
    /// <summary>
    /// This resolve example demonstrates the use of the <see cref="Autofac.Features.Indexed.IIndex<K,V>"/> type with delegate factories (whether implicit or explicit).
    /// For basic usage of IIndex see: http://docs.autofac.org/en/latest/advanced/keyed-services.html#resolving-with-an-index
    /// </summary>
    public class IndexedFuncResolve : IResolveAction
    {
        public void Execute(ILifetimeScope container)
        {
            var index = container.Resolve<IIndex<ExampleEnum, Func<string, uint, Shareholding> >>();
            Console.WriteLine($"index[ExampleEnum.TheOnlyState]: Id: {index[ExampleEnum.TheOnlyState]("ABC", 1234).Id}");

            index = container.Resolve<IIndex<ExampleEnum, Func<string, uint, Shareholding>>>();
            Console.WriteLine($"index[ExampleEnum.TheOnlyState]: Id: {index[ExampleEnum.TheOnlyState]("ABC", 1234).Id}");

            index = container.Resolve<IIndex<ExampleEnum, Func<string, uint, Shareholding>>>();
            Console.WriteLine($"index[ExampleEnum.TheOnlyState]: Id: {index[ExampleEnum.TheOnlyState]("DEF", 5678).Id}");

        }
    }
}