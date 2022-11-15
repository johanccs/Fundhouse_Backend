using FH.Domain.ValueObjects;
using System;

namespace FH.Domain.Entities
{
    public class HistoryEntity: BaseEntity
    {
        public HistoryEntity()
        {
            var _internalId = new HistoryEntityId().Create();

            if (string.IsNullOrEmpty(_internalId.ToString()))
                throw new ArgumentNullException(nameof(_internalId), "Invalid Id");

            Id = _internalId;
        }
    }
}
