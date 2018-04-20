using DomainDrivenCore.NHibernate.Helpers;
using DomainDrivenCore.SampleDomain;
using DomainDrivenCore.SampleWeb.Commands;
using DomainDrivenCore.SampleWeb.Contracts;
using DomainDrivenCore.SampleWeb.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DomainDrivenCore.SampleWeb.Controllers
{
    [Route("api/[controller]")]
    public class ParentController : DomainController
    {
        // GET api/parent
        [HttpGet]
        public IActionResult Get(ListOptions listOptions)
        {
            return WrapQuery(new ParentQuery(listOptions));
        }

        // POST api/parent
        [HttpPost]
        public IActionResult Post([FromBody] ParentDto dto)
        {
            return WrapCreate(new ParentUpdater(dto));
        }

        // PUT api/parent
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ParentDto dto)
        {
            return WrapUpdate(id, new ParentUpdater(dto));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            return WrapDelete<Parent>(id);
        }
    }
}