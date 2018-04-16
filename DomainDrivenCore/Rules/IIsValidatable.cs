using System.Collections.Generic;

namespace DomainDrivenCore.Rules
{
    public interface IIsValidatable
    {
        bool IsValid(out IEnumerable<string> validationErrors);
    }
}