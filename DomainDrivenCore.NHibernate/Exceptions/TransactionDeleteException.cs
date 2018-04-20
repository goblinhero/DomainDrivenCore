using System;

namespace DomainDrivenCore.NHibernate.Exceptions
{
    public class TransactionDeleteException : Exception
    {
        public TransactionDeleteException(ITransaction transaction)
            : base($"{transaction.GetType().Name} with id:{transaction.Id} was attempted deleted.")
        {
        }
    }
}