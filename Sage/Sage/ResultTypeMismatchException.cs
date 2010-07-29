using System;

namespace Sage
{
    public class ResultTypeMismatchException : ApplicationException
    {
        public ResultTypeMismatchException(Type resultType, Type propertyType)
            : base("The result property type " + propertyType.Name + " can't be cast to the expected result type " + resultType.Name + ".")
        {
            
        }
    }
}