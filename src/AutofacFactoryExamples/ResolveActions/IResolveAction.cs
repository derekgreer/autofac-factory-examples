using Autofac;

namespace AutofacFactoryExamples.ResolveActions
{
    public interface IResolveAction
    {
        void Execute(ILifetimeScope container);
    }
}