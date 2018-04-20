using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainDrivenCore.NHibernate.Exceptions
{
    public class InvalidTransactionalUpdateException : Exception
    {
        public InvalidTransactionalUpdateException(string message, IEnumerable<string> falselyUpdatedColumns)
            : base(message)
        {
            FalselyUpdatedColumns = falselyUpdatedColumns.ToList();
        }

        public IEnumerable<string> FalselyUpdatedColumns { get; }
    }
}