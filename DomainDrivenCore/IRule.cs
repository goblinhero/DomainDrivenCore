namespace DomainDrivenCore
{
    public interface IRule<T>
    {
        string BrokenMessage { get; }
        bool IsBroken(T entity);
    }
}