using System.Collections.Generic;

namespace CompanySelf.Infrastructure.Validation
{
    public class ErrorResponse
    {
        public List<string> Errors { get; set; } = new List<string>();
    }
}