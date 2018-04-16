using System;
using System.Collections.Generic;
using DomainDrivenCore.Rules;

namespace DomainDrivenCore
{
    public abstract class BusinessTransaction<TTransactional> : ITransaction
        where TTransactional : class, ITransaction
    {
        public virtual long Id { get; protected set; }
        public virtual int Version { get; private set; }
        public virtual IEnumerable<string> UpdateableColumns => new[] { "Version" };
        public virtual DateTime Created { get; set; }
        public virtual bool IsValid(out IEnumerable<string> errors)
        {
            return new RuleSet<TTransactional>(GetValidationRuleSet()).UpholdsRules(this as TTransactional, out errors);
        }

        protected virtual IEnumerable<IRule<TTransactional>> GetValidationRuleSet()
        {
            return new IRule<TTransactional>[0];
        }
    }
}