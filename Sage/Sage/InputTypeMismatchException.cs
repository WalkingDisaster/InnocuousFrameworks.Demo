using System;

namespace Sage
{
    public class InputTypeMismatchException : ApplicationException
    {
        public InputTypeMismatchException(Type parameterType, Type propertyType)
            : base("The input object type " + parameterType.Name + "cannot be assigned to the input property type " + propertyType.Name)
        {
            
        }
    }
}