using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainDrivenCore.NHibernate.Helpers
{
    public class PagedResultSet<T>
    {
        public PagedResultSet(IEnumerable<T> entities)
        {
            Entities = entities.ToList();
            TotalCount = Entities.Count;
        }
        public PagedResultSet(IEnumerable<T> entities, int totalCount)
        {
            Entities = entities.ToList();
            TotalCount = totalCount;
        }
        public IList<T> Entities { get; }
        public int TotalCount { get; }
    }
}
