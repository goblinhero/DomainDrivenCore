using System;
using System.Collections.Generic;
using DomainDrivenCore.Rules;

namespace DomainDrivenCore
{
    public abstract class Entity<T> : IEntity
        where T : Entity<T>
    {
        public virtual long Id { get; protected set; }
        public virtual int Version { get; private set; }
        public virtual DateTime Created { get; set; }

        public virtual bool IsValid(out IEnumerable<string> validationErrors)
        {
            return new RuleSet<T>(GetValidationRules()).UpholdsRules(this as T, out validationErrors);
        }

        protected virtual IEnumerable<IRule<T>> GetValidationRules()
        {
            return new IRule<T>[0];
        }
    }
}