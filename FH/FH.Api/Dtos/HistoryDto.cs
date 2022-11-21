using System;
using System.ComponentModel.DataAnnotations;

namespace FH.Api.Dtos
{
    public class HistoryDto
    {
        public DateTime Timestamp { get; set; }
        [Required]
        public decimal Rate { get; set; }
    }
}
