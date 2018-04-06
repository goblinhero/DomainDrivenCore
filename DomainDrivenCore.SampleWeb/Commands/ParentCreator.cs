using System.Collections.Generic;
using DomainDrivenCore.NHibernate;
using DomainDrivenCore.SampleDomain;
using DomainDrivenCore.SampleWeb.Contracts;
using NHibernate;

namespace DomainDrivenCore.SampleWeb.Commands
{
    public class ParentUpdater : BaseExecutable, IEntityUpdater<Parent>, IEntityCreator<Parent>
    {
        private readonly ParentDto _dto;

        public ParentUpdater(ParentDto dto)
        {
            _dto = dto;
        }

        public bool TryCreate(ISession session, out Parent entity, out IEnumerable<string> errors)
        {
            entity = new Parent();
            return TryUpdate(session, entity, out errors);
        }

        public bool TryUpdate(ISession sesion, Parent entity, out IEnumerable<string> errors)
        {
            entity.Description = _dto.Description;
            return Success(out errors);
        }
    }
}