using System;
using System.Collections.Generic;

namespace FH.Api.Dtos
{
    public class QuoteResponseDto
    {
        public string BaseCcy { get; set; }
        public string QuoteCcy { get; set; }
        public decimal QuoteAmount { get; set; }
        public DateTime Date { get; set; }
        public List<HistoryDto> History { get; set; } = new();
    }
}
