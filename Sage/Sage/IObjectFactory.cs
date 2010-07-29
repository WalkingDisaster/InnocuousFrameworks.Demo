namespace Sage
{
    public interface IObjectFactory
    {
        T Create<T>();
    }
}