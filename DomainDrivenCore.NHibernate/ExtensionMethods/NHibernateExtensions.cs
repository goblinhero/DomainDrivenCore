using DomainDrivenCore.NHibernate.Helpers;
using NHibernate;

namespace DomainDrivenCore.NHibernate.ExtensionMethods
{
    public static class NHibernateExtensions
    {
        public static PagedResultSet<T> ToPagedSet<T>(this IQueryOver<T, T> query, ListOptions listOptions)
        {
            var count = query.ToRowCountQuery().FutureValue<int>();
            var results = query.Skip(listOptions.PageSize * listOptions.Page).Take(listOptions.PageSize).Future();
            return new PagedResultSet<T>(results, count.Value);
        }
    }
}