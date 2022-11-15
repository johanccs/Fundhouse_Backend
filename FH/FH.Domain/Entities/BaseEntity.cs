using System;

namespace FH.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public abstract void Validate(string baseCcy, string quoteCcy, decimal amount);
    }
}
