using DomainDrivenCore.NHibernate;
using DomainDrivenCore.SampleWeb.Contracts;
using NHibernate.Mapping.ByCode.Conformist;

namespace DomainDrivenCore.SampleWeb.Database.Mappings.Dto
{
    public class ChildDtoMapping : ClassMapping<ChildDto>
    {
        public ChildDtoMapping()
        {
            Table("Child");
            this.AddEntityDto<ChildDtoMapping, ChildDto>();
            Property(m => m.Description);
            Property(m => m.ParentId);
        }
    }
}