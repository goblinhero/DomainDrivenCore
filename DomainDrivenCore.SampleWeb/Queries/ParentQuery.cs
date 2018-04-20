using System.Collections.Generic;
using DomainDrivenCore.NHibernate;
using DomainDrivenCore.NHibernate.ExtensionMethods;
using DomainDrivenCore.NHibernate.Helpers;
using DomainDrivenCore.SampleWeb.Contracts;
using NHibernate;

namespace DomainDrivenCore.SampleWeb.Queries
{
    public class ParentQuery : BaseExecutable, IExecutableQuery<PagedResultSet<ParentDto>>
    {
        private readonly ListOptions _listOptions;

        public ParentQuery(ListOptions listOptions)
        {
            _listOptions = listOptions;
        }

        public bool TryExecute(ISession session, out PagedResultSet<ParentDto> result, out IEnumerable<string> errors)
        {
            result = session.QueryOver<ParentDto>()
                .ToPagedSet(_listOptions);
            return Success(out errors);
        }
    }
}