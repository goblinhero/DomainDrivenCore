using DomainDrivenCore.Rules;

namespace DomainDrivenCore
{
    public interface IEntity : IIsValidatable, IHasId, IHasCreationDate
    {
        int Version { get; }
    }
}