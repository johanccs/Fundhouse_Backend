using FH.Domain.DbModels;
using FH.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace FH.Domain.Entities
{
    public sealed class QuoteEntity 
    {
        public string BaseCcy { get; private set; }
        public string QuoteCcy { get; private set; }
        public decimal Amount { get; private set; }
        public decimal QuoteAmount { get; private set; }
        public DateTime Date { get; private set; } 
        public decimal ConversionRate { get; private set; }
        public IEnumerable<History>History { get; set; }

        public QuoteEntity()
        {
            History = new List<History>();
            Amount = -1;
            QuoteAmount = -1;
            ConversionRate = 0.0M;
            Date = DateTime.Now.Date;
        }

        public QuoteEntity(string baseCcy, string quoteCcy, decimal amount, decimal conversionRate=0, decimal quoteAmount=0)
        {
            try
            {
                Validate(baseCcy, quoteCcy, amount);

                BaseCcy = baseCcy;
                QuoteCcy = quoteCcy;
                Amount = amount;
                QuoteAmount = quoteAmount;
                ConversionRate = conversionRate;
                Date = DateTime.Now.Date;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Validate(string baseCcy, string quoteCcy, decimal amount)
        {
            if (string.IsNullOrEmpty(baseCcy))
                throw new InvalidQuoteEntityException("Base Currency must contain a value");

            if(string.IsNullOrEmpty(quoteCcy))
                throw new InvalidQuoteEntityException("Quote Currency must contain a value");

            if(amount < 0)
                throw new InvalidQuoteEntityException("Amount cannot be less than 0");
        }
    }
}
