namespace CompanySelf.Core.Models
{
    public abstract class Entity<T> where T : struct
    {
        public T Id { get; protected set; }
    }
}