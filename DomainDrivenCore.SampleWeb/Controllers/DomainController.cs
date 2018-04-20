using System.Collections.Generic;
using DomainDrivenCore.NHibernate;
using DomainDrivenCore.SampleWeb.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenCore.SampleWeb.Controllers
{
    public abstract class DomainController : Controller
    {
        private readonly SessionHelper _sessionHelper = new SessionHelper();

        protected IActionResult WrapQuery<T>(IExecutableQuery<T> query)
        {
            return _sessionHelper.TryExecuteQuery(query, out var parents, out var errors)
                ? Ok(parents)
                : Error(errors);
        }

        protected IActionResult WrapGet<T>(long id)
        {
            return _sessionHelper.TryExecuteQuery(new GetQuery<T>(id), out var result, out var errors)
                ? Ok(result)
                : Error(errors);
        }

        protected IActionResult WrapCreate<T>(IEntityCreator<T> creator)
            where T : IEntity
        {
            return _sessionHelper.TryCreateEntity(creator, out var assignedId, out var errors)
                ? Ok(SaveResultDto.SuccessResult(assignedId))
                : Error(errors);
        }

        protected IActionResult WrapUpdate<T>(long id, IEntityUpdater<T> updater)
            where T : IEntity
        {
            return _sessionHelper.TryUpdateEntity(updater, id, out var errors)
                ? Ok(SaveResultDto.SuccessResult(id))
                : Error(errors);
        }

        public IActionResult WrapDelete<T>(long id)
            where T : IEntity
        {
            return _sessionHelper.TryDeleteEntity<T>(id, out var errors)
                ? Ok(SaveResultDto.SuccessResult())
                : Error(errors);
        }

        protected IActionResult Error(IEnumerable<string> errors)
        {
            return BadRequest(SaveResultDto.ErrorResult(errors));
        }
    }
}