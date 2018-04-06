using System.Collections.Generic;
using DomainDrivenCore.NHibernate;
using DomainDrivenCore.SampleDomain;
using DomainDrivenCore.SampleWeb.Commands;
using DomainDrivenCore.SampleWeb.Contracts;
using DomainDrivenCore.SampleWeb.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenCore.SampleWeb.Controllers
{
    [Route("api/[controller]")]
    public class ParentController : Controller
    {
        private readonly SessionHelper _sessionHelper = new SessionHelper();

        // GET api/parent
        [HttpGet]
        public IEnumerable<ParentDto> Get()
        {
            return _sessionHelper.TryExecuteQuery(new ParentQuery(), out var parents, out var _)
                ? parents
                : null;
        }

        // POST api/parent
        [HttpPost]
        public SaveResultDto Post([FromBody] ParentDto dto)
        {
            return _sessionHelper.TryCreateEntity(new ParentUpdater(dto), out var assignedId, out var errors)
                ? SaveResultDto.SuccessResult(assignedId)
                : SaveResultDto.ErrorResult(errors);
        }

        // PUT api/parent
        [HttpPut("{id}")]
        public SaveResultDto Put(long id, [FromBody] ParentDto dto)
        {
            return _sessionHelper.TryUpdateEntity(new ParentUpdater(dto), id, out var errors)
                ? SaveResultDto.SuccessResult(id)
                : SaveResultDto.ErrorResult(errors);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public SaveResultDto Delete(long id)
        {
            return _sessionHelper.TryDeleteEntity<Parent>(id, out var errors)
                ? SaveResultDto.SuccessResult()
                : SaveResultDto.ErrorResult(errors);
        }
    }
}