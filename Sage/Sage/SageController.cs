using System;
using System.Web.Mvc;

namespace Sage
{
    public class SageController : Controller
    {
        public IObjectFactory ObjectFactory { get; set; }

        public SageController()
        {
            ObjectFactory = new MyObjectFactory();
        }

        public void ExecuteCommand<TCommand>()
            where TCommand : class
        {
            if (!ModelState.IsValid)
                return;
            var command = new CommandExecutionAdapter<TCommand>(ObjectFactory);
            command.Execute();
            var result = command.TryToGetResult<IModifiesModelState>();
            if (result != null)
                result.UpdateModelState(ModelState);
        }

        public TResult ExecuteCommand<TCommand, TResult>()
            where TCommand : class
            where TResult : class
        {
            var command = new CommandExecutionAdapter<TCommand, TResult>(ObjectFactory);
            if (!ModelState.IsValid)
                return command.GetResult();
            command.Execute();
            var result = command.GetResult();
            if (result != null && result is IModifiesModelState)
            {
                ((IModifiesModelState) result).UpdateModelState(ModelState);
            }
            return result;
        }

        public void ExecuteCommand<TCommand>(object input)
            where TCommand : class
        {
            if (!ModelState.IsValid)
                return;
            var command = new CommandExecutionAdapter<TCommand>(ObjectFactory);
            command.SetInput(input);
            command.Execute();
            var result = command.TryToGetResult<IModifiesModelState>();
            if (result != null)
                result.UpdateModelState(ModelState);
        }

        public TResult ExecuteCommand<TCommand, TResult>(object input)
            where TCommand : class
            where TResult : class
        {
            var command = new CommandExecutionAdapter<TCommand, TResult>(ObjectFactory);
            if (!ModelState.IsValid)
                return command.GetResult();
            command.SetInput(input);
            command.Execute();
            var result = command.GetResult();
            if (result != null && result is IModifiesModelState)
            {
                ((IModifiesModelState)result).UpdateModelState(ModelState);
            }
            return result;
        }

        private class MyObjectFactory : IObjectFactory
        {
            public T Create<T>()
            {
                return Activator.CreateInstance<T>();
            }
        }
    }
}