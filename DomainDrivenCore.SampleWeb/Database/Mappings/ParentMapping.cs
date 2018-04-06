using DomainDrivenCore.NHibernate;
using DomainDrivenCore.SampleDomain;
using NHibernate.Mapping.ByCode.Conformist;

namespace DomainDrivenCore.SampleWeb.Database.Mappings
{
    public class ParentMapping : ClassMapping<Parent>
    {
        public ParentMapping()
        {
            this.AddEntity<ParentMapping, Parent>();
            Property(e => e.Description, pm => pm.NotNullable(true));
        }
    }
}