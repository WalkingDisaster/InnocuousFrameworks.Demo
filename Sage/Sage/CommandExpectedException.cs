using System;

namespace Sage
{
    public class CommandExpectedException : ApplicationException
    {
        public CommandExpectedException(Type type)
            : base("The specified command type " + type.Name + " does not contain a parameterless \"Execute\" method.")
        {
            
        }
    }
}