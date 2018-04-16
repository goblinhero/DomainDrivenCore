using System;
using System.Collections.Generic;

namespace DomainDrivenCore.NHibernate.Exceptions
{
    public class NonValidException:Exception
    {
        public NonValidException(object validatable, IEnumerable<string> errors)
            : base ($"{validatable.GetType().Name} is not valid. Errors: {string.Join(", ", errors)}")
        {
        }
    }
}
