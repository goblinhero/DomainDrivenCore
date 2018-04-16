using System.Collections.Generic;
using NHibernate;

namespace DomainDrivenCore.NHibernate
{
    public interface IExecutableQuery<T>
    {
        bool TryExecute(ISession session, out T result, out IEnumerable<string> errors);
    }
}