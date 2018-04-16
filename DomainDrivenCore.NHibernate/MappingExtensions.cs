using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace DomainDrivenCore.NHibernate
{
    public static class MappingExtensions
    {
        public static void AddEntity<TMapping, TType>(this TMapping mapping)
            where TMapping : ClassMapping<TType>
            where TType : class, IEntity
        {
            mapping.Id(m => m.Id, m => m.Generator(Generators.HighLow, g => g.Params(new {max_lo = 100})));
            mapping.Version(m => m.Version, m => m.Column("[Version]"));
            mapping.Property(m => m.Created, pm => pm.NotNullable(true));
        }

        public static void AddEntityDto<TMapping, TType>(this TMapping mapping)
            where TMapping : ClassMapping<TType>
            where TType : class, IEntityDto
        {
            mapping.Lazy(false);
            mapping.Mutable(false);
            mapping.Id(m => m.Id, m => m.Generator(Generators.Assigned));
            mapping.Property(m => m.Version, m => m.Column("[Version]"));
            mapping.Property(m => m.Created, pm => pm.NotNullable(true));
        }
    }
}