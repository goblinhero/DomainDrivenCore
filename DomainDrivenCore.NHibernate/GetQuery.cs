using System.Collections.Generic;
using NHibernate;

namespace DomainDrivenCore.NHibernate
{
    public class GetQuery<T> : BaseExecutable, IExecutableQuery<T>
    {
        private readonly object _id;

        public GetQuery(object id)
        {
            _id = id;
        }

        public bool TryExecute(ISession session, out T result, out IEnumerable<string> errors)
        {
            result = session.Get<T>(_id);
            return result != null ? Success(out errors):NotFound<T>(out errors,_id);
        }
    }
}