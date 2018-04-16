using System.Collections.Generic;
using System.Linq;
using DomainDrivenCore.Rules;

namespace DomainDrivenCore.SampleDomain
{
    public class Child : Entity<Child>
    {
        protected Child()
        {
        }

        public Child(Parent parent)
        {
            Parent = parent;
        }

        public virtual string Description { get; set; }
        public virtual Parent Parent { get; protected set; }
        protected override IEnumerable<IRule<Child>> GetValidationRules()
        {
            return new IRule<Child>[]
            {
                new RelayRule<Child>(c => string.IsNullOrWhiteSpace(c.Description),"Parents must have a description"),
                new RelayRule<Child>(c => c.Parent == null,"Childs must have a parent"),
            }.Concat(base.GetValidationRules());
        }
    }
}