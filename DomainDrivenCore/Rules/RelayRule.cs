using System;

namespace DomainDrivenCore.Rules
{
    public class RelayRule<T> : IRule<T>
    {
        private readonly Predicate<T> _isBrokenWhen;

        public RelayRule(Predicate<T> isBrokenWhen, string brokenMessage)
        {
            _isBrokenWhen = isBrokenWhen;
            BrokenMessage = brokenMessage;
        }

        public string BrokenMessage { get; }
        public bool IsBroken(T entity)
        {
            return _isBrokenWhen(entity);
        }
    }
}