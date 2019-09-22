using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySelf.Domain.Entities
{
    public abstract class Entity<T> where T: struct
    {
        public T Id { get; protected set; }
    }
}
