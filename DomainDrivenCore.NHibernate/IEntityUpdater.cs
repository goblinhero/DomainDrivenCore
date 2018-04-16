using System.Collections.Generic;
using NHibernate;

namespace DomainDrivenCore.NHibernate
{
    public interface IEntityUpdater<T>
        where T : IEntity
    {
        bool TryUpdate(ISession sesion, T entity, out IEnumerable<string> errors);
    }
}