using DomainDrivenCore.NHibernate;
using DomainDrivenCore.SampleDomain;
using NHibernate.Mapping.ByCode.Conformist;

namespace DomainDrivenCore.SampleWeb.Database.Mappings
{
    public class ChildMapping : ClassMapping<Child>
    {
        public ChildMapping()
        {
            this.AddEntity<ChildMapping, Child>();
            Property(e => e.Description, pm => pm.NotNullable(true));
            ManyToOne(e => e.Parent);
        }
    }
}