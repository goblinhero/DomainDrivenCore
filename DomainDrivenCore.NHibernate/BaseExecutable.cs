using System.Collections.Generic;
using System.Linq;

namespace DomainDrivenCore.NHibernate
{
    public abstract class BaseExecutable
    {
        protected bool Success(out IEnumerable<string> errors)
        {
            errors = Enumerable.Empty<string>();
            return true;
        }

        protected bool Error(out IEnumerable<string> errors, params string[] error)
        {
            errors = error;
            return false;
        }

        protected bool NotFound<T>(out IEnumerable<string> errors, params object[] ids)
        {
            return Error(out errors, ids.Select(id => $"{typeof(T).Name} with Id: {id} not found").ToArray());
        }
    }
}