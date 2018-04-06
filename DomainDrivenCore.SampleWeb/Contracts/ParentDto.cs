using DomainDrivenCore.NHibernate;

namespace DomainDrivenCore.SampleWeb.Contracts
{
    public class ParentDto : EntityDto
    {
        public string Description { get; set; }
    }
}