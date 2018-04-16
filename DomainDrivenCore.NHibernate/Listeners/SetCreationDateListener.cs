using System;
using System.Threading;
using System.Threading.Tasks;
using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace DomainDrivenCore.NHibernate.Listeners
{
    public class SetCreationDateListener : IPreInsertEventListener
    {
        public async Task<bool> OnPreInsertAsync(PreInsertEvent ev, CancellationToken cancellationToken)
        {
            return !cancellationToken.IsCancellationRequested && OnPreInsert(ev);
        }

        public bool OnPreInsert(PreInsertEvent ev)
        {
            if (!(ev.Entity is IHasCreationDate entity))
                return false;
            var createdAt = DateTime.UtcNow;
            Set(ev.Persister, ev.State, "Created", createdAt);
            entity.Created = createdAt;
            return false;
        }

        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }
    }
}