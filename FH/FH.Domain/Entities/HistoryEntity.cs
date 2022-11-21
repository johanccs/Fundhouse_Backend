using System;

namespace FH.Domain.Entities
{
    public sealed class HistoryEntity
    {
        public DateTime Timestamp { get; set; }
        public decimal Rate { get; set; }
    }
}
