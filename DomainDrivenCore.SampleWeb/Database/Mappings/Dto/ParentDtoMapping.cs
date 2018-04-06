using DomainDrivenCore.NHibernate;
using DomainDrivenCore.SampleWeb.Contracts;
using NHibernate.Mapping.ByCode.Conformist;

namespace DomainDrivenCore.SampleWeb.Database.Mappings.Dto
{
    public class ParentDtoMapping : ClassMapping<ParentDto>
    {
        public ParentDtoMapping()
        {
            Table("Parent");
            this.AddEntityDto<ParentDtoMapping, ParentDto>();
            Property(m => m.Description);
        }
    }
}