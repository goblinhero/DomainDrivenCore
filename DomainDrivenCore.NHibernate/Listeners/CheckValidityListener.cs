using System.Threading;
using System.Threading.Tasks;
using DomainDrivenCore.NHibernate.Exceptions;
using DomainDrivenCore.Rules;
using NHibernate.Event;

namespace DomainDrivenCore.NHibernate.Listeners
{
    public class CheckValidityListener : IPreInsertEventListener, IPreUpdateEventListener
    {
        public async Task<bool> OnPreInsertAsync(PreInsertEvent ev, CancellationToken cancellationToken)
        {
            return !cancellationToken.IsCancellationRequested && OnPreInsert(ev);
        }

        public bool OnPreInsert(PreInsertEvent ev)
        {
            CheckValidity(ev);
            return false;
        }

        public async Task<bool> OnPreUpdateAsync(PreUpdateEvent ev, CancellationToken cancellationToken)
        {
            return !cancellationToken.IsCancellationRequested && OnPreUpdate(ev);
        }

        public bool OnPreUpdate(PreUpdateEvent ev)
        {
            CheckValidity(ev);
            return false;
        }

        private void CheckValidity(IPreDatabaseOperationEventArgs ev)
        {
            if (!(ev.Entity is IIsValidatable)) return;
            var validatable = (IIsValidatable)ev.Entity;
            if (!validatable.IsValid(out var errors))
                throw new NonValidException(validatable, errors);
        }
    }
}