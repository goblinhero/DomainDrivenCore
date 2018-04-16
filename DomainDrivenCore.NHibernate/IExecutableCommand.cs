using System.Collections.Generic;
using NHibernate;

namespace DomainDrivenCore.NHibernate
{
    public interface IExecutableCommand
    {
        bool TryExecute(ISession session, out IEnumerable<string> errors);
    }
}