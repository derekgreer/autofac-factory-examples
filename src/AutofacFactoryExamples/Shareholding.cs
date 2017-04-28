using System;

namespace AutofacFactoryExamples
{
    public class Shareholding
    {
        // ------------------------------------------------------------------------------------------
        // The delegate factory
        //
        // Note: Autofac matches parameters by name which requires the delegate parameter names
        //       to match the class parameter names.  This also allows for multiple parameters
        //       of the same type and for the the parameter order to vary between the delegate
        //       and the class and .
        // ------------------------------------------------------------------------------------------
        public delegate Shareholding Factory(string symbol, uint holding);

        public Shareholding(string symbol, uint holding)
        {
            Symbol = symbol;
            Holding = holding;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public string Symbol { get; }

        public uint Holding { get; set; }
    }
}