namespace DomainDrivenCore.Rules
{
    public interface IRule<T>
    {
        string BrokenMessage { get; }
        bool IsBroken(T entity);
    }
}