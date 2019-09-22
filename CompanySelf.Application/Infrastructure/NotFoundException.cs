using System;

namespace CompanySelf.Application.Infrastructure
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}