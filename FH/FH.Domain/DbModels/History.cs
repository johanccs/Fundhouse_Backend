using System;
using System.ComponentModel.DataAnnotations;

namespace FH.Domain.DbModels
{
    public class History
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string BaseCurrency { get; set; }
        [Required]
        public string ExchangeCurrency { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}
