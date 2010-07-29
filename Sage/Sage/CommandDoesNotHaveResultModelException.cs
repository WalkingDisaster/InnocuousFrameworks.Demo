using System;

namespace Sage
{
    public class CommandDoesNotHaveResultModelException : ApplicationException
    {
        public CommandDoesNotHaveResultModelException(Type commandType)
            : base("The command class " + commandType.Name + " does not have a gettable parameter named \"Result\".")
        {
        }
    }
}