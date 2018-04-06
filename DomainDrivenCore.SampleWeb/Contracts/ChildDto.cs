using DomainDrivenCore.NHibernate;

namespace DomainDrivenCore.SampleWeb.Contracts
{
    public class ChildDto : EntityDto
    {
        public string Description { get; set; }
        public long ParentId { get; set; }
    }
}