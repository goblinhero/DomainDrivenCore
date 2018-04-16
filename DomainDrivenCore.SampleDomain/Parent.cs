using System.Collections.Generic;
using System.Linq;
using DomainDrivenCore.Rules;

namespace DomainDrivenCore.SampleDomain
{
    public class Parent : Entity<Parent>
    {
        public virtual string Description { get; set; }
        protected override IEnumerable<IRule<Parent>> GetValidationRules()
        {
            return new IRule<Parent>[]
            {
                new RelayRule<Parent>(p => string.IsNullOrWhiteSpace(p.Description),"Parents must have a description")
            }.Concat(base.GetValidationRules());
        }
    }
}