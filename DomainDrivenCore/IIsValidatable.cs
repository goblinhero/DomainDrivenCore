using System.Collections.Generic;

namespace DomainDrivenCore
{
    public interface IIsValidatable
    {
        bool IsValid(out IEnumerable<string> validationErrors);
    }
}