using System;

namespace FH.Api.Dtos
{
    public class QuoteRequestDto
    {
        public string BaseCcy { get; set; }
        public string QuoteCcy { get; set; }
        public decimal Amount { get; set; }
    }
}
