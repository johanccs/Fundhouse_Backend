using FH.Api.Dtos;
using FH.Domain.DbModels;
using FH.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FH.Api.Helper
{
    internal static class Mapper
    {
        internal static QuoteEntity MapToEntity(QuoteRequestDto dto) => 
            new QuoteEntity(dto.BaseCcy, dto.QuoteCcy, dto.Amount);

        internal static QuoteResponseDto MapToDto(QuoteEntity entity) =>
            new QuoteResponseDto
            {
                BaseCcy = entity.BaseCcy,
                Date = entity.Date,
                QuoteAmount = entity.QuoteAmount,
                QuoteCcy = entity.QuoteCcy,
                History = MaptoHistoryDto(entity.History)
            };
        
        internal static List<HistoryDto> MaptoHistoryDto(IEnumerable<History> history)
        {
            var historyList = new List<HistoryDto>();
            history.ToList().ForEach(x =>
            {
                historyList.Add(new HistoryDto { Rate = x.Value, Timestamp = x.Date });
            });

            return historyList;
        }
    }
}
