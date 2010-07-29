using System;

namespace Sage
{
    public class InputMissingException : ApplicationException
    {
        public InputMissingException(Type type)
            : base("The command type " + type.Name + " does not contain a settable \"Input\" property.")
        {
            
        }
    }
}