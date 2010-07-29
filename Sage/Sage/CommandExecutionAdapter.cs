using System;
using System.Reflection;
using System.Web.Mvc;

namespace Sage
{
    public class CommandExecutionAdapter<TCommand> : ICommandExecutionAdapter
        where TCommand : class
    {
        private readonly Lazy<TCommand> _instance;
        protected TCommand Instance { get { return _instance.Value; } }
        protected Type CommandType { get { return typeof (TCommand);}}

        protected virtual void BeforeExecute()
        {
            // hook
        }

        public CommandExecutionAdapter(IObjectFactory objectFactory)
        {
            _instance = new Lazy<TCommand>(objectFactory.Create<TCommand>);
        }

        public void SetInput(object input)
        {
            var property = CommandType.GetProperty("Input", BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
            if (property == null)
            {
                throw new InputMissingException(CommandType);
            }
            var propertyType = property.PropertyType;
            if (!input.GetType().IsAssignableFrom(propertyType))
            {
                throw new InputTypeMismatchException(input.GetType(), propertyType);
            }
            property.SetValue(Instance, input, null);
        }

        public void Execute()
        {
            var execute = CommandType.GetMethod("Execute", BindingFlags.Public | BindingFlags.Instance, null,
                                                 new Type[] {}, null);
            if (execute == null || execute.ReturnType != typeof(void))
            {
                throw new CommandExpectedException(CommandType);
            }
            execute.Invoke(Instance, new object[] {});
        }

        public TResult TryToGetResult<TResult>()
        {
            var result = CommandType.GetProperty("Result",
                                                BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty,
                                                null, typeof(TResult), new Type[] { }, null);
            if (result == null)
            {
                return default(TResult);
            }
            if (!result.PropertyType.IsAssignableFrom(typeof(TResult)))
            {
                return default(TResult);
            }
            return (TResult)result.GetValue(Instance, new object[] { });
        }
    }

    public class CommandExecutionAdapter<TCommand, TResult> : CommandExecutionAdapter<TCommand>, ICommandExecutionAdapter<TResult>
        where TCommand : class
        where TResult : class
    {
        protected Type ResultType { get { return typeof (TResult);}}

        public CommandExecutionAdapter(IObjectFactory objectFactory) : base(objectFactory)
        {
        }

        public TResult GetResult()
        {
            var result = CommandType.GetProperty("Result",
                                                 BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty,
                                                 null, typeof (TResult), new Type[] {}, null);
            if (result == null)
            {
                throw new CommandDoesNotHaveResultModelException(CommandType);
            }
            if (!result.PropertyType.IsAssignableFrom(typeof(TResult)))
            {
                throw new ResultTypeMismatchException(typeof (TResult), result.PropertyType);
            }
            return (TResult) result.GetValue(Instance, new object[] {});
        }
    }
}