using System;

namespace FH.Domain.ValueObjects
{
    public class QuoteEntityId
    {
        public Guid Create() => Guid.NewGuid();
    }
}
