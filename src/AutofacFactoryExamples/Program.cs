using System;
using AutofacFactoryExamples.RegistrationActions;
using AutofacFactoryExamples.ResolveActions;

namespace AutofacFactoryExamples
{
    /// <summary>
    ///     Demonstrates various approaches to using factories within Autofac.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegate Factory Resolve Example (default lifetime)");
            new Example<SharholdingRegistrationPerDependency, FactoryResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Delegate Factory Resolve Example (singleton lifetime)");
            new Example<SharholdingRegistrationSingleton, FactoryResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Func Resolve Example (default lifetime)");
            new Example<SharholdingRegistrationPerDependency, FuncResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Func Resolve Example (singleton lifetime)");
            new Example<SharholdingRegistrationSingleton, FuncResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Explcit Delegate Factory Registration / Named Parameters / Factory Resolve Example (default lifetime)");
            new Example<ExplicitDelegateFactoryNamedParametersPerDependency, FactoryResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Explcit Delegate Factory Registration / Named Parameters / Factory Resolve Example (singleton lifetime)");
            new Example<ExplicitDelegateFactoryNamedParametersSingleton, FactoryResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);
            
            Console.WriteLine("Explcit Delegate Factory Registration / Typed Parameters / Func Resolve Example (default lifetime)");
            new Example<ExplicitDelegateFactoryTypedParametersPerDependency, FuncResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Explcit Delegate Factory Registration / Typed Parameters / Func Resolve Example (singleton lifetime)");
            new Example<ExplicitDelegateFactoryTypedParametersSingleton, FuncResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Explcit Func Registration / Factory Resolve Example (default lifetime)");
            new Example<ExplicitFuncPerDependency, FactoryResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Explcit Func Registration / Factory Resolve Example (service singleton lifetime)");
            new Example<ExplicitFuncSingletonService, FactoryResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Explcit Func Registration / Factory Resolve Example (delegate singleton lifetime) <- note lifetime not respected");
            new Example<ExplicitFuncSingletonDelegate, FactoryResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Explcit Func Registration / Func Resolve Example (default lifetime)");
            new Example<ExplicitFuncPerDependency, FuncResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Explcit Func Registration / Func Resolve Example (service singleton lifetime)");
            new Example<ExplicitFuncSingletonService, FuncResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Explcit Func Registration / Func Resolve Example (delegate singleton lifetime) <- note: lifetime not respected");
            new Example<ExplicitFuncSingletonDelegate, FuncResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Explcit Func Registration / Indexed Func Resolve (default lifetime)");
            new Example<IndexPerDependency, IndexedFuncResolve>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Explcit Func Registration / Indexed Func Resolve Example (singleton lifetime)");
            new Example<IndexSingleton, IndexedFuncResolve>().Run();
            Console.WriteLine(Environment.NewLine);
            
            // This example registers a memoized Func<> and runs the resolve example in seperate lifetime containers
            // to demonstrate that the lifetime scope is properly respected.
            Console.WriteLine("Memoized Registration / Func Resolve Example");
            new ExampleWithSeparateLifetimes<MemoizedFunc, FuncResolveAction>().Run();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }

    public class Example<TRegistrationAction, TResolveAction>
        where TRegistrationAction: IRegistrationAction, new()
        where TResolveAction: IResolveAction, new()
    {
        public void Run()
        {
            var container = new TRegistrationAction().Execute();
            new TResolveAction().Execute(container);
        }
    }

    public class ExampleWithSeparateLifetimes<TRegistrationAction, TResolveAction>
        where TRegistrationAction : IRegistrationAction, new()
        where TResolveAction : IResolveAction, new()
    {
        public void Run()
        {
            var container = new TRegistrationAction().Execute();
            using (var scope = container.BeginLifetimeScope())
            {
                new TResolveAction().Execute(scope);
            }

            using (var scope = container.BeginLifetimeScope())
            {
                new TResolveAction().Execute(scope);
            }
        }
    }
}