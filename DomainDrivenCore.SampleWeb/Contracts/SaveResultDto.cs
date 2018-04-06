using System.Collections.Generic;
using System.Linq;

namespace DomainDrivenCore.SampleWeb.Contracts
{
    public class SaveResultDto
    {
        private SaveResultDto(bool success, IEnumerable<string> errors, long? assignedId = null)
        {
            Success = success;
            AssignedId = assignedId;
            Errors = errors.ToArray();
        }

        public bool Success { get; }
        public long? AssignedId { get; }
        public string[] Errors { get; }

        public static SaveResultDto SuccessResult(long? assignedId = null)
        {
            return new SaveResultDto(true, new string[0], assignedId);
        }

        public static SaveResultDto ErrorResult(IEnumerable<string> errors)
        {
            return new SaveResultDto(false, errors);
        }
    }
}