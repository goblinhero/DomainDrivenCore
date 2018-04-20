using System.Threading;
using System.Threading.Tasks;
using DomainDrivenCore.NHibernate.Exceptions;
using NHibernate.Event;

namespace DomainDrivenCore.NHibernate.Listeners
{
    public class DisallowDeleteTransactionListener : IPreDeleteEventListener
    {
        public async Task<bool> OnPreDeleteAsync(PreDeleteEvent ev, CancellationToken cancellationToken)
        {
            return !cancellationToken.IsCancellationRequested && OnPreDelete(ev);
        }

        public bool OnPreDelete(PreDeleteEvent ev)
        {
            if (ev.Entity is ITransaction transaction) throw new TransactionDeleteException(transaction);
            return false;
        }
    }
}