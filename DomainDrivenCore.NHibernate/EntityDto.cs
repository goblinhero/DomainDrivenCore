using System;

namespace DomainDrivenCore.NHibernate
{
    public class EntityDto : IEntityDto
    {
        public long? Id { get; set; }
        public int Version { get; set; }
        public DateTime Created { get; set; }
    }
}