using System.Collections.Generic;
using System.Linq;

namespace DomainDrivenCore.Rules
{
    public class RuleSet<T>
    {
        private readonly IEnumerable<IRule<T>> _rules;

        public RuleSet(IEnumerable<IRule<T>> rules)
        {
            _rules = rules;
        }

        public bool UpholdsRules(T entity, out IEnumerable<string> validationErrors)
        {
            var brokenRules = _rules
                .Where(r => r.IsBroken(entity))
                .ToList();
            validationErrors = brokenRules.Select(r => r.BrokenMessage).ToArray();
            return !brokenRules.Any();
        }
    }
}