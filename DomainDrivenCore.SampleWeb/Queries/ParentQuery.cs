using System.Collections.Generic;
using DomainDrivenCore.NHibernate;
using DomainDrivenCore.SampleWeb.Contracts;
using NHibernate;

namespace DomainDrivenCore.SampleWeb.Queries
{
    public class ParentQuery : BaseExecutable, IExecutableQuery<IEnumerable<ParentDto>>
    {
        public bool TryExecute(ISession session, out IEnumerable<ParentDto> result, out IEnumerable<string> errors)
        {
            result = session.QueryOver<ParentDto>().List();
            return Success(out errors);
        }
    }
}