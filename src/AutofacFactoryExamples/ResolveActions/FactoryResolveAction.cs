using System;
using Autofac;

namespace AutofacFactoryExamples.ResolveActions
{
    public class FactoryResolveAction : IResolveAction
    {
        public void Execute(ILifetimeScope container)
        {
            var shareholdingFactory = container.Resolve<Shareholding.Factory>();
            Console.WriteLine($"factory(\"ABC\", 1234): Id: {shareholdingFactory("ABC", 1234).Id}");
            Console.WriteLine($"factory(\"ABC\", 1234): Id: {shareholdingFactory("ABC", 1234).Id}");
            Console.WriteLine($"factory(\"DEF\", 5678): Id: {shareholdingFactory("DEF", 5678).Id}");
        }
    }
}