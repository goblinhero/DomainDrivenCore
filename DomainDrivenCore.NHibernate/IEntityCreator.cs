using System.Collections.Generic;
using NHibernate;

namespace DomainDrivenCore.NHibernate
{
    public interface IEntityCreator<T>
        where T : IEntity
    {
        bool TryCreate(ISession session, out T entity, out IEnumerable<string> errors);
    }
}