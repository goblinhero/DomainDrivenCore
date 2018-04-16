using System;

namespace DomainDrivenCore.NHibernate
{
    public interface IEntityDto
    {
        long? Id { get; set; }
        int Version { get; set; }
        DateTime Created { get; set; }
    }
}