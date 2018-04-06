using System;

namespace DomainDrivenCore
{
    public interface IEntity : IIsValidatable
    {
        long Id { get; }
        int Version { get; }
        DateTime Created { get; set; }
    }
}