using System;
using System.Collections.Generic;
using DomainDrivenCore.Rules;

namespace DomainDrivenCore
{
    public interface ITransaction : IIsValidatable, IHasId, IHasCreationDate
    {
        IEnumerable<string> UpdateableColumns { get; }
        int Version { get; }
    }

    public interface IHasCreationDate
    {
        DateTime Created { get; set; }
    }
}