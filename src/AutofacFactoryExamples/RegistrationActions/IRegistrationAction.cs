using Autofac;

namespace AutofacFactoryExamples.RegistrationActions
{
    public interface IRegistrationAction
    {
        IContainer Execute();

    }
}