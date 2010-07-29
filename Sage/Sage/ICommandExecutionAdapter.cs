namespace Sage
{
    public interface ICommandExecutionAdapter
    {
        void SetInput(object input);
        void Execute();
    }

    public interface ICommandExecutionAdapter<TResult> : ICommandExecutionAdapter
    {
        TResult GetResult();
    }
}