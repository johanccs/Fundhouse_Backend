using System;

namespace FH.Domain.ValueObjects
{
    public class HistoryEntityId
    {
        public Guid Create() => Guid.NewGuid();
    }
}
